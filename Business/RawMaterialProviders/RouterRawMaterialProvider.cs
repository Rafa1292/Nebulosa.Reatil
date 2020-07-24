using Business.Measures;
using Business.ModelsDTO;
using Business.Providers;
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

        public RouterRawMaterialProvider(IRawMaterialProvider rawMaterialProvider, RouterProvider provider, RouterMeasure measure)
        {
            _rawMaterialProvider = rawMaterialProvider;
            _provider = provider;
            _measure = measure;
        }

        public ObjectResponse<bool> Insert(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, int rawMaterialId)
        {
            using (var scope = new TransactionScope())
            {
                var rawMaterialProviders = MapperRawMaterialProvider.MapFromDTO(rawMaterialProvidersDTO);
                rawMaterialProviders = Finisher.FinishToInsert(rawMaterialProviders, rawMaterialId);

                var validation = ValidateRawMaterialProvider.ValidateToInsert(rawMaterialProviders);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _rawMaterialProvider.Insert(rawMaterialProviders);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, int rawMaterialProviderId)
        {
            using (var scope = new TransactionScope())
            {
                var rawMaterialProviders = MapperRawMaterialProvider.MapFromDTO(rawMaterialProvidersDTO);
                rawMaterialProviders = Finisher.FinishToUpdate(rawMaterialProviders);

                var validation = ValidateRawMaterialProvider.ValidateToInsert(rawMaterialProviders);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _rawMaterialProvider.Update(rawMaterialProviders, rawMaterialProviderId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
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

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);
            rawMaterialProvidersDTO = Finisher.FinishToGetAll(rawMaterialProvidersDTO, providersDTO.Data, measuresDTO.Data);

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

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);
            rawMaterialProvidersDTO = Finisher.FinishToGetAll(rawMaterialProvidersDTO, providersDTO.Data, measuresDTO.Data);


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

            var rawMaterialProvidersDTO = MapperRawMaterialProvider.MapToDTO(actionResponse.Data);
            rawMaterialProvidersDTO = Finisher.FinishToGetAll(rawMaterialProvidersDTO, providersDTO.Data, measuresDTO.Data);

            return new ObjectResponse<List<RawMaterialProviderDTO>>(true, actionResponse.Message, rawMaterialProvidersDTO);
        }
    }
}
