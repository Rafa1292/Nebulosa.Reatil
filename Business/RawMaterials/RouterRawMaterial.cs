using Business.ModelsDTO;
using Business.RawMaterialProviders;
using Common;
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
                var rawMaterial = MapperRawMaterial.MapFromDTO(rawMaterialDTO, new Common.Models.RawMaterial());
                rawMaterial = Finisher.FinishToInsert(rawMaterial);

                var rawMaterials = _rawMaterial.GetAll(false);
                if (!rawMaterials.IsSuccess)
                    return new ObjectResponse<bool>(false, rawMaterials.Message);

                var validation = ValidateRawMaterial.ValidateToInsert(rawMaterial, rawMaterials.Data);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _rawMaterial.Insert(rawMaterial);
                if (!actionResponse.IsSuccess)
                    return actionResponse;

                scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(RawMaterialDTO rawMaterialDTO)
        {
            using (var scope = new TransactionScope())
            {
                var rawMaterial = MapperRawMaterial.MapFromDTO(rawMaterialDTO, new Common.Models.RawMaterial());
                rawMaterial = Finisher.FinishToUpdate(rawMaterial);

                var rawMaterials = _rawMaterial.GetAll(false);
                if (!rawMaterials.IsSuccess)
                    return new ObjectResponse<bool>(false, rawMaterials.Message);

                var validation = ValidateRawMaterial.ValidateToInsert(rawMaterial, rawMaterials.Data);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _rawMaterial.Update(rawMaterial);
                if (!actionResponse.IsSuccess)
                    return actionResponse;

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

            var rawMaterialsDTO = MapperRawMaterial.MapToDTO(rawMaterials.Data);
            rawMaterialsDTO = Finisher.FinishToGetAll(rawMaterialsDTO, new List<RawMaterialProviderDTO>());


            return new ObjectResponse<List<RawMaterialDTO>>(true, rawMaterials.Message, rawMaterialsDTO);
        }
    }
}
