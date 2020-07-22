using Business.ModelsDTO;
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

        public RouterRawMaterialProvider(IRawMaterialProvider rawMaterialProvider)
        {
            _rawMaterialProvider = rawMaterialProvider;
        }

        public ObjectResponse<bool> Insert(RawMaterialProviderDTO rawMaterialProviderDTO)
        {
            using (var scope = new TransactionScope())
            {
                var rawMaterialProviders = _rawMaterialProvider.GetAll(false);
                if (!rawMaterialProviders.IsSuccess)
                    return new ObjectResponse<bool>(false, rawMaterialProviders.Message);

                var rawMaterialProvider = MapperRawMaterialProvider.MapFromDTO(rawMaterialProviderDTO, new RawMaterialProvider());
                rawMaterialProvider = Finisher.FinishToInsert(rawMaterialProvider);

                var validation = ValidateRawMaterialProvider.ValidateToInsert(rawMaterialProvider);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _rawMaterialProvider.Insert(rawMaterialProvider);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(RawMaterialProviderDTO rawMaterialProviderDTO)
        {
            using (var scope = new TransactionScope())
            {
                var rawMaterialProviders = _rawMaterialProvider.GetAll(false);
                if (!rawMaterialProviders.IsSuccess)
                    return new ObjectResponse<bool>(false, rawMaterialProviders.Message);

                var currentRawMaterialProvider = rawMaterialProviders.Data.Find(x => x.RawMaterialProviderId == rawMaterialProviderDTO.RawMaterialProviderId);
                if (currentRawMaterialProvider == null)
                    return new ObjectResponse<bool>(false, "Imposible acceder a la informacion de esta relacion");

                var rawMaterialProvider = MapperRawMaterialProvider.MapFromDTO(rawMaterialProviderDTO, currentRawMaterialProvider);
                rawMaterialProvider = Finisher.FinishToUpdate(rawMaterialProvider);

                var validation = ValidateRawMaterialProvider.ValidateToInsert(rawMaterialProvider);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _rawMaterialProvider.Update(rawMaterialProvider);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int rawMaterialProviderId)
        {
            using (var scope = new TransactionScope())
            {
                var actionResponse = _rawMaterialProvider.Delete(rawMaterialProviderId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<List<RawMaterialProviderDTO>> GetByRawMaterial(int rawMaterialId)
        {
            var actionResponse = _rawMaterialProvider.GetByRawMaterial(rawMaterialId);

            if (!actionResponse.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, actionResponse.Message);

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);

            return new ObjectResponse<List<RawMaterialProviderDTO>>(true, actionResponse.Message, rawMaterialProvidersDTO);
        }

        public ObjectResponse<List<RawMaterialProviderDTO>> GetByProvider(int providerId)
        {
            var actionResponse = _rawMaterialProvider.GetByProvider(providerId);

            if (!actionResponse.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, actionResponse.Message);

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);

            return new ObjectResponse<List<RawMaterialProviderDTO>>(true, actionResponse.Message, rawMaterialProvidersDTO);
        }

        public ObjectResponse<List<RawMaterialProviderDTO>> GetAll(bool deleteItems)
        {
            var actionResponse = _rawMaterialProvider.GetAll(deleteItems);
            if (!actionResponse.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderDTO>>(false, actionResponse.Message);

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);

            return new ObjectResponse<List<RawMaterialProviderDTO>>(true, actionResponse.Message, rawMaterialProvidersDTO);
        }
    }
}
