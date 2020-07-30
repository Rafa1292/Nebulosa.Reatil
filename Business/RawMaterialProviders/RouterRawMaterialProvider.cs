using Business.Measures;
using Business.ModelsDTO;
using Business.Providers;
using Business.RawMaterialProviderBrands;
using Business.RawMaterials;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
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
            foreach (var rawMaterialProvider in rawMaterialProvidersDTO)
            {
                var actionResponse = Insert(rawMaterialProvider, rawMaterialId);
                if (!actionResponse.IsSuccess)
                    return actionResponse;
            }

            return new ObjectResponse<bool>(true, "Relacion exitosa");
        }

        public ObjectResponse<bool> Insert(RawMaterialProviderDTO rawMaterialProviderDTO, int rawMaterialId)
        {
            var validation = PrepareToDataBase(rawMaterialProviderDTO, rawMaterialId, new RawMaterialProvider());
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

        public ObjectResponse<bool> Update(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, int rawMaterialProviderId)
        {
            using (var scope = new TransactionScope())
            {
                return new ObjectResponse<bool>(false, "Sin implementar");
            }
        }

        public ObjectResponse<bool> Delete(List<int> rawMaterialProvidersId)
        {
            using (var scope = new TransactionScope())
            {
                var actionResponse = _rawMaterialProvider.Delete(rawMaterialProvidersId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
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

        public ObjectResponse<RawMaterialProvider> PrepareToDataBase(RawMaterialProviderDTO rawMaterialProviderDTO, int rawMaterialId, RawMaterialProvider currentRawMaterialProvider)
        {
            var rawMaterialProvidersDTO = GetAll(false);
            if (!rawMaterialProvidersDTO.IsSuccess)
                return new ObjectResponse<RawMaterialProvider>(false, rawMaterialProvidersDTO.Message);

            var validateDontRepeatProviderBrand = ValidateRawMaterialProvider.ValidateDontRepeatBrandByProvider(rawMaterialProviderDTO, rawMaterialProvidersDTO.Data);
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
