using Business.Measures;
using Business.ModelsDTO;
using Business.Providers;
using Business.RawMaterialProviderBrands;
using Business.RawMaterials;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.RawMaterialProviders
{
    public class RouterRawMaterialProvider
    {
        private readonly IRawMaterialProvider _rawMaterialProvider;
        private readonly RouterProvider _provider;
        private readonly RouterMeasure _measure;
        private readonly RouterRawMaterialProviderBrand _rawMaterialProviderBrand;

        public RouterRawMaterialProvider(IRawMaterialProvider rawMaterialProvider, RouterProvider provider, RouterMeasure measure, RouterRawMaterialProviderBrand rawMaterialProviderBrand)
        {
            _rawMaterialProvider = rawMaterialProvider;
            _provider = provider;
            _measure = measure;
            _rawMaterialProviderBrand = rawMaterialProviderBrand;
        }

        public ObjectResponse<bool> InsertList(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, int rawMaterialId)
        {
            using (var scope = new TransactionScope())
            {
                var currentRawMaterialProvidersDTO = GetCurrentRawMaterialProvidersDTO(rawMaterialId);
                foreach (var rawMaterialProvider in rawMaterialProvidersDTO)
                {
                    var actionResponse = Insert(rawMaterialProvider, rawMaterialId, currentRawMaterialProvidersDTO);
                    if (!actionResponse.IsSuccess)
                        return actionResponse;
                }

                scope.Complete();
                return new ObjectResponse<bool>(true, "Relacion exitosa");
            }
        }

        public ObjectResponse<bool> Insert(RawMaterialProviderDTO rawMaterialProviderDTO, int rawMaterialId, List<RawMaterialProviderDTO> currentRawMaterialProvidersDTO)
        {
            var validation = PrepareToDataBase(rawMaterialProviderDTO, rawMaterialId, new RawMaterialProvider(), currentRawMaterialProvidersDTO);
            if (!validation.IsSuccess)
                return new ObjectResponse<bool>(false, validation.Message);

            var rawMaterialProvider = validation.Data;

            var actionResponse = _rawMaterialProvider.Insert(rawMaterialProvider);
            if (!actionResponse.IsSuccess)
                return new ObjectResponse<bool>(false, actionResponse.Message);

            var relationResponse = _rawMaterialProviderBrand.Insert(rawMaterialProviderDTO.RawMaterialProviderBrandDTO, actionResponse.Data);
            if (!relationResponse.IsSuccess)
                return relationResponse;

            return relationResponse;
        }

        public ObjectResponse<bool> RouterUpdate(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, int rawMaterialId)
        {
            using (var scope = new TransactionScope())
            {
                var currentRawMaterialProviders = GetByRawMaterial(rawMaterialId);
                if (!currentRawMaterialProviders.IsSuccess)
                    return new ObjectResponse<bool>(false, "No se puede actualizar la relacion con los proveedores en este momento");

                var rawMaterialProvidersToUpdate = rawMaterialProvidersDTO.Where(x => x.IsEdited && x.RawMaterialProviderId > 0).ToList();
                var rawMaterialProvidersToInsert = rawMaterialProvidersDTO.Where(y => !currentRawMaterialProviders.Data.Select(x => x.RawMaterialProviderId).Contains(y.RawMaterialProviderId)).ToList();
                var rawMaterialProvidersToDelete = currentRawMaterialProviders.Data.Where(y => !rawMaterialProvidersDTO.Select(x => x.RawMaterialProviderId).Contains(y.RawMaterialProviderId)).ToList();
                //obtener listas y dividir: add, delete, update, campo isEdited en DTO se activa onchange en campos

                var insertResponse = InsertList(rawMaterialProvidersToInsert, rawMaterialId);
                if (!insertResponse.IsSuccess)
                    return insertResponse;

                var updateResponse = UpdateList(rawMaterialProvidersToUpdate, rawMaterialId);
                if (!updateResponse.IsSuccess)
                    return updateResponse;

                var deleteResponse = Delete(rawMaterialProvidersToDelete.Select(x => x.RawMaterialProviderId).ToList());
                if (!deleteResponse.IsSuccess)
                    return deleteResponse;

                scope.Complete();
                return new ObjectResponse<bool>(true, "Actualizacion completada");
            }
        }

        public ObjectResponse<bool> UpdateList(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, int rawMaterialId)
        {
            var currentRawMaterialProvidersDTO = GetCurrentRawMaterialProvidersDTO(rawMaterialId);

            foreach (var rawMaterialProvider in rawMaterialProvidersDTO)
            {
                var actionResponse = Update(rawMaterialProvider, currentRawMaterialProvidersDTO);
                if (!actionResponse.IsSuccess)
                    return actionResponse;
            }

            return new ObjectResponse<bool>(true, "Relacion editada exitosamente");
        }

        public ObjectResponse<bool> Update(RawMaterialProviderDTO rawMaterialProviderDTO, List<RawMaterialProviderDTO> currentRawMaterialProvidersDTO)
        {
            var currentRawMaterialProvider = _rawMaterialProvider.GetAll(false).Data.Find(x => x.RawMaterialProviderId == rawMaterialProviderDTO.RawMaterialProviderId);

            var validation = PrepareToDataBase(rawMaterialProviderDTO, rawMaterialProviderDTO.RawMaterialId, currentRawMaterialProvider, currentRawMaterialProvidersDTO);
            if (!validation.IsSuccess)
                return new ObjectResponse<bool>(false, validation.Message);

            var rawMaterialProvider = validation.Data;

            var actionResponse = _rawMaterialProvider.Update(rawMaterialProvider);
            if (!actionResponse.IsSuccess)
                return new ObjectResponse<bool>(false, actionResponse.Message);

            var relationResponse = _rawMaterialProviderBrand.Update(rawMaterialProviderDTO.RawMaterialProviderBrandDTO);

            return relationResponse;
        }

        public ObjectResponse<bool> Delete(List<int> rawMaterialProvidersId)
        {
            var actionResponse = _rawMaterialProvider.Delete(rawMaterialProvidersId);
            if (!actionResponse.IsSuccess)
                return actionResponse;

            var rawMaterialProviderBrandsToDelete = GetRelationsToDelete(rawMaterialProvidersId);
            if (!rawMaterialProviderBrandsToDelete.IsSuccess)
                return new ObjectResponse<bool>(false, rawMaterialProviderBrandsToDelete.Message);

            var actionRelations = DeleteRelations(rawMaterialProviderBrandsToDelete.Data);
            if (!actionRelations.IsSuccess)
                return actionRelations;

            return actionResponse;
        }

        public ObjectResponse<List<RawMaterialProviderBrandDTO>> GetRelationsToDelete(List<int> rawMaterialProvidersId)
        {
            var rawMaterialProviderBrands = _rawMaterialProviderBrand.GetAll(false);
            if (!rawMaterialProviderBrands.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(false, rawMaterialProviderBrands.Message);

            var rawMaterialProviderBrandsToDelete = rawMaterialProviderBrands.Data.Where(x => rawMaterialProvidersId.Contains(x.RawMaterialProviderId)).ToList();
            
            return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(true, "Consulta exitosa", rawMaterialProviderBrandsToDelete);
        }

        public ObjectResponse<bool> DeleteRelations(List<RawMaterialProviderBrandDTO> rawMaterialProviderBrands)
        {
            foreach (var rawMaterialProviderBrand in rawMaterialProviderBrands)
            {
                var response = _rawMaterialProviderBrand.Delete(rawMaterialProviderBrand.RawMaterialProviderBrandId);
                if (!response.IsSuccess)
                    return response;
            }

            return new ObjectResponse<bool>(true, "Relacion eliminada");
        }

        public ObjectResponse<List<RawMaterialProviderDTO>> GetByRawMaterial(int rawMaterialId)
        {
            var providersDTO = _provider.GetAll(false);
            if (!providersDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, providersDTO.Message);

            var measuresDTO = _measure.GetAll(false);
            if (!measuresDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, measuresDTO.Message);

            var actionResponse = _rawMaterialProvider.GetByRawMaterial(rawMaterialId);

            if (!actionResponse.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, actionResponse.Message);

            var rawMaterialProviderBrandsDTO = _rawMaterialProviderBrand.GetAll(false);
            if (!rawMaterialProviderBrandsDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, rawMaterialProviderBrandsDTO.Message);

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);
            rawMaterialProvidersDTO = Finisher.FinishToGetAll(rawMaterialProvidersDTO, providersDTO.Data, measuresDTO.Data, rawMaterialProviderBrandsDTO.Data);

            return new ObjectResponse<List<RawMaterialProviderDTO>>(true, actionResponse.Message, rawMaterialProvidersDTO);
        }

        public ObjectResponse<List<RawMaterialProviderDTO>> GetByProvider(int providerId)
        {
            var providersDTO = _provider.GetAll(false);
            if (!providersDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, providersDTO.Message);

            var measuresDTO = _measure.GetAll(false);
            if (!measuresDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, measuresDTO.Message);

            var actionResponse = _rawMaterialProvider.GetByProvider(providerId);

            if (!actionResponse.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, actionResponse.Message);

            var rawMaterialProviderBrandsDTO = _rawMaterialProviderBrand.GetAll(false);
            if (!rawMaterialProviderBrandsDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, rawMaterialProviderBrandsDTO.Message);

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);
            rawMaterialProvidersDTO = Finisher.FinishToGetAll(rawMaterialProvidersDTO, providersDTO.Data, measuresDTO.Data, rawMaterialProviderBrandsDTO.Data);


            return new ObjectResponse<List<RawMaterialProviderDTO>>(true, actionResponse.Message, rawMaterialProvidersDTO);
        }

        public ObjectResponse<List<RawMaterialProviderDTO>> GetAll(bool deleteItems)
        {
            var actionResponse = _rawMaterialProvider.GetAll(deleteItems);
            if (!actionResponse.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, actionResponse.Message);

            var providersDTO = _provider.GetAll(deleteItems);
            if (!providersDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, providersDTO.Message);

            var measuresDTO = _measure.GetAll(deleteItems);
            if (!measuresDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, measuresDTO.Message);

            var rawMaterialProviderBrandsDTO = _rawMaterialProviderBrand.GetAll(deleteItems);
            if (!rawMaterialProviderBrandsDTO.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, rawMaterialProviderBrandsDTO.Message);

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);
            rawMaterialProvidersDTO = Finisher.FinishToGetAll(rawMaterialProvidersDTO, providersDTO.Data, measuresDTO.Data, rawMaterialProviderBrandsDTO.Data);

            return new ObjectResponse<List<RawMaterialProviderDTO>>(true, actionResponse.Message, rawMaterialProvidersDTO);
        }

        public List<RawMaterialProviderDTO> GetCurrentRawMaterialProvidersDTO(int rawMaterialId)
        {
            var rawMaterialProvidersDTO = GetAll(false);
            if (!rawMaterialProvidersDTO.IsSuccess)
                return new List<RawMaterialProviderDTO>();

            return rawMaterialProvidersDTO.Data.Where(x => x.RawMaterialId == rawMaterialId).ToList();
        }

        public ObjectResponse<RawMaterialProvider> PrepareToDataBase(RawMaterialProviderDTO rawMaterialProviderDTO, int rawMaterialId,
                                                                    RawMaterialProvider currentRawMaterialProvider, List<RawMaterialProviderDTO> currentRawMaterialProvidersDTO)
        {
            var validateDontRepeatProviderBrand = ValidateRawMaterialProvider.ValidateDontRepeatBrandByProvider(rawMaterialProviderDTO, currentRawMaterialProvidersDTO);
            if (!validateDontRepeatProviderBrand.IsSuccess)
                return new ObjectResponse<RawMaterialProvider>(false, validateDontRepeatProviderBrand.Message);

            var rawMaterialProvider = MapperRawMaterialProvider.MapFromDTO(rawMaterialProviderDTO, currentRawMaterialProvider);
            rawMaterialProvider = Finisher.FinishToDatabase(rawMaterialProvider, rawMaterialId);

            var validation = ValidateRawMaterialProvider.ValidateToInsert(rawMaterialProvider);
            if (!validation.IsSuccess)
                return new ObjectResponse<RawMaterialProvider>(false, validation.Message);

            return new ObjectResponse<RawMaterialProvider>(true, "Listo para insertar", rawMaterialProvider);
        }

    }
}
