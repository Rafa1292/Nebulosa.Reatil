using Business.ModelsDTO;
using Business.Routes;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Providers
{
    public class RouterProvider
    {
        private readonly IProvider _provider;
        private readonly RouterRoute _route;

        public RouterProvider(IProvider provider, RouterRoute route)
        {
            _provider = provider;
            _route = route;
        }

        public ObjectResponse<bool> Insert(ProviderDTO providerDTO)
        {
            using (var scope = new TransactionScope())
            {

                var routeRelationship = _route.Insert(providerDTO.Route);
                if (!routeRelationship.IsSuccess)
                {
                    scope.Dispose();
                    return new ObjectResponse<bool>(false, routeRelationship.Message);
                }

                var providers = _provider.GetAll(false);
                if (!providers.IsSuccess)
                    return new ObjectResponse<bool>(false, providers.Message);

                var provider = MapperProvider.MapFromDTO(providerDTO, new Provider());
                provider = Finisher.FinishToInsert(provider, routeRelationship.Data);
                var validation = ValidateProvider.ValidateToInsert(provider, providers.Data.ToList());

                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _provider.Insert(provider);
                if (!actionResponse.IsSuccess)
                {
                    scope.Dispose();
                    return actionResponse;
                }



                scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(ProviderDTO providerDTO)
        {
            using (var scope = new TransactionScope())
            {

                var routeRelationship = _route.Update(providerDTO.Route);
                if (!routeRelationship.IsSuccess)
                {
                    scope.Dispose();
                    return new ObjectResponse<bool>(false, routeRelationship.Message);
                }
                var providers = _provider.GetAll(false);
                if (!providers.IsSuccess)
                    return new ObjectResponse<bool>(false, providers.Message);

                var currentProvider = providers.Data.ToList().Find(x => x.ProviderId == providerDTO.ProviderId);
                if(currentProvider == null)
                    return new ObjectResponse<bool>(false, "No se puede acceder a la informacion actual del proveedor");


                var provider = MapperProvider.MapFromDTO(providerDTO, currentProvider);
                provider = Finisher.FinishToUpdate(provider);
                var validation = ValidateProvider.ValidateToInsert(provider, providers.Data.ToList());

                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _provider.Update(provider);
                if (!actionResponse.IsSuccess)
                {
                    scope.Dispose();
                    return actionResponse;
                }

                scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int providerId)
        {
            using (var scope = new TransactionScope())
            {
                var provider = _provider.Get(providerId);
                if (!provider.IsSuccess)
                {
                    scope.Dispose();
                    return new ObjectResponse<bool>(false, provider.Message);
                }
                var actionResponse = _provider.Delete(providerId);
                if (!actionResponse.IsSuccess)
                {
                    scope.Dispose();
                    return actionResponse;
                }

                var routeRelationship = _route.Delete(provider.Data.RouteId);
                if (!routeRelationship.IsSuccess)
                {
                    scope.Dispose();
                    return routeRelationship;
                }

                scope.Complete();
                return actionResponse;
            }
        }

        public ObjectResponse<ProviderDTO> Get(int providerId)
        {
            var provider = _provider.Get(providerId);
            if (!provider.IsSuccess)
                return new ObjectResponse<ProviderDTO>(false, provider.Message);

            var route = _route.Get(provider.Data.RouteId);
            if (!route.IsSuccess)
                return new ObjectResponse<ProviderDTO>(false, route.Message);

            var providerDTO = MapperProvider.MapToDTO(provider.Data);
            providerDTO = Finisher.FinishToGet(providerDTO, route.Data);

            return new ObjectResponse<ProviderDTO>(true, route.Message, providerDTO);
        }

        public ObjectResponse<List<ProviderDTO>> GetAll(bool deleteItems)
        {
            var provider = _provider.GetAll(deleteItems);
            if (!provider.IsSuccess)
                return new ObjectResponse<List<ProviderDTO>>(false, provider.Message);

            var route = _route.GetAll(deleteItems);
            if (!route.IsSuccess)
                return new ObjectResponse<List<ProviderDTO>>(false, route.Message);

            var providersDTO = MapperProvider.MapToDTO(provider.Data.ToList());
            providersDTO = Finisher.FinishToGetAll(providersDTO, route.Data);

            return new ObjectResponse<List<ProviderDTO>>(true, route.Message, providersDTO);
        }
    }
}
