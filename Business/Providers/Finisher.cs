using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Providers
{
    public class Finisher
    {
        public static Provider FinishToInsert(Provider provider, int routeId)
        {
            provider.RouteId = routeId;
            provider.DateCreate = DateTime.Now;
            provider.DateUpdate = DateTime.Now;
            provider.UserCreate = "";//pendiente de implementar
            provider.UserUpdate = "";//pendiente de implementar

            return provider;
        }

        public static Provider FinishToUpdate(Provider provider)
        {
            provider.DateUpdate = DateTime.Now;
            provider.UserUpdate = "";//pendiente de implementar

            return provider;
        }

        public static ProviderDTO FinishToGet(ProviderDTO providerDTO, RouteDTO routeDTO)
        {
            providerDTO.Route = routeDTO;

            return providerDTO;
        }

        public static List<ProviderDTO> FinishToGetAll(List<ProviderDTO> providersDTO, List<RouteDTO> routesDTO)
        {
            providersDTO.ForEach(x => x.Route = routesDTO.Find(y => y.RouteId == x.RouteId));

            return providersDTO;
        }
    }
}
