using Business.ModelsDTO;
using Business.RawMaterialProviders;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.RawMaterials
{
    public class RouterRawMaterial
    {
        private readonly IRawMaterial _rawMaterial;
        private readonly RouterRawMaterialProvider _rawMaterialProvider;

        public RouterRawMaterial(IRawMaterial rawMaterial, RouterRawMaterialProvider rawMaterialProvider)
        {
            _rawMaterial = rawMaterial;
            _rawMaterialProvider = rawMaterialProvider;
        }

        public ObjectResponse<bool> Insert(RawMaterialDTO rawMaterialDTO)
        {
            using (var scope = new TransactionScope())
            {                
                var validation = PrepareToDataBase(rawMaterialDTO, new RawMaterial());
                if (!validation.IsSuccess)
                    return new ObjectResponse<bool>(false, validation.Message);

                var rawMaterial = validation.Data;

                var actionResponse = _rawMaterial.Insert(rawMaterial);
                if (!actionResponse.IsSuccess)
                    return new ObjectResponse<bool>(false, actionResponse.Message);

                var relationship = InsertRelations(rawMaterialDTO.rawMaterialProvidersDTO, rawMaterial.RawMaterialId);
                if (!relationship.IsSuccess)
                    return relationship;

                scope.Complete();

                return new ObjectResponse<bool>(true, "Insumo creado exitosamente");
            }
        }

        public ObjectResponse<bool> InsertRelations(List<RawMaterialProviderDTO> rawMaterialProviders, int rawMaterialId)
        {
            var actionResponse = _rawMaterialProvider.InsertList(rawMaterialProviders, rawMaterialId);
            return actionResponse;
        }

        public ObjectResponse<bool> Update(RawMaterialDTO rawMaterialDTO)
        {
            using (var scope = new TransactionScope())
            {
                var currentRawMaterial = GetCurrentRawMaterial(rawMaterialDTO.RawMaterialId);
                if (currentRawMaterial == null)
                    return new ObjectResponse<bool>(false, "No se encuentra el insumo a actualiar");

                var validation = PrepareToDataBase(rawMaterialDTO, currentRawMaterial);
                if (!validation.IsSuccess)
                    return new ObjectResponse<bool>(false, validation.Message);

                var rawMaterial = validation.Data;

                var actionResponse = _rawMaterial.Update(rawMaterial);
                if (!actionResponse.IsSuccess)
                    return actionResponse;

                var editRealtionshipResponse = _rawMaterialProvider.RouterUpdate(rawMaterialDTO.rawMaterialProvidersDTO, rawMaterial.RawMaterialId);
                if (!editRealtionshipResponse.IsSuccess)
                    return editRealtionshipResponse;

                scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int rawMaterialId)
        {
            using (var scope = new TransactionScope())
            {
                var actionResponse = _rawMaterial.Delete(rawMaterialId);
                if (!actionResponse.IsSuccess)
                    return actionResponse;

                var rawMaterialProviders = _rawMaterialProvider.GetByRawMaterial(rawMaterialId);
                if (!rawMaterialProviders.IsSuccess)
                    return new ObjectResponse<bool>(false, rawMaterialProviders.Message);

                var deleteRelationshipResponse = _rawMaterialProvider.Delete(rawMaterialProviders.Data.Select(x => x.RawMaterialProviderId).ToList());
                if (!deleteRelationshipResponse.IsSuccess)
                    return deleteRelationshipResponse;

                scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<RawMaterialDTO> Get(int rawMaterialId)
        {
            var rawMaterial = _rawMaterial.Get(rawMaterialId);
            if (!rawMaterial.IsSuccess)
                return new ObjectResponse<RawMaterialDTO>(false, rawMaterial.Message);

            var rawMaterialProviders = _rawMaterialProvider.GetAll(false);
            if (!rawMaterialProviders.IsSuccess)
                return new ObjectResponse<RawMaterialDTO>(false, rawMaterialProviders.Message);

            var rawMaterialDTO = MapperRawMaterial.MapToDTO(rawMaterial.Data);
            rawMaterialDTO = Finisher.FinishToGet(rawMaterialDTO, rawMaterialProviders.Data);

            return new ObjectResponse<RawMaterialDTO>(true, rawMaterial.Message, rawMaterialDTO);
        }

        public ObjectResponse<List<RawMaterialDTO>> GetAll(bool deleteItems)
        {
            var rawMaterials = _rawMaterial.GetAll(deleteItems);
            if (!rawMaterials.IsSuccess)
                return new ObjectResponse<List<RawMaterialDTO>>(false, rawMaterials.Message);

            var rawMaterialProviders = _rawMaterialProvider.GetAll(false);
            if (!rawMaterialProviders.IsSuccess)
                return new ObjectResponse<List<RawMaterialDTO>>(false, rawMaterialProviders.Message);

            var rawMaterialsDTO = MapperRawMaterial.MapToDTO(rawMaterials.Data);
            rawMaterialsDTO = Finisher.FinishToGetAll(rawMaterialsDTO, rawMaterialProviders.Data);

            return new ObjectResponse<List<RawMaterialDTO>>(true, rawMaterials.Message, rawMaterialsDTO);
        }

        public RawMaterial GetCurrentRawMaterial(int rawMaterialId)
        {
            if (rawMaterialId > 0)
            {
                var tryGetRawMaterial = _rawMaterial.Get(rawMaterialId);
                if (tryGetRawMaterial.IsSuccess)
                    return tryGetRawMaterial.Data;               
                
            }

            return null;
        }

        public ObjectResponse<RawMaterial> PrepareToDataBase(RawMaterialDTO rawMaterialDTO, RawMaterial currentRawMaterial)
        {
            var rawMaterial = MapperRawMaterial.MapFromDTO(rawMaterialDTO, currentRawMaterial);
            rawMaterial = Finisher.FinishToDatabase(rawMaterial);

            var rawMaterials = _rawMaterial.GetAll(false);
            if (!rawMaterials.IsSuccess)
                return new ObjectResponse<RawMaterial>(false, rawMaterials.Message);

            var validation = ValidateRawMaterial.ValidateToInsert(rawMaterial, rawMaterials.Data);
            if (!validation.IsSuccess)
                return new ObjectResponse<RawMaterial>(false, validation.Message);

            return new ObjectResponse<RawMaterial>(true, "Listo para insertar", rawMaterial);
        }
    }
}
