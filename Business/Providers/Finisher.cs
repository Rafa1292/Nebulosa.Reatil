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
            providerDTO.RouteShortcut = GetShortCut(routeDTO);
            return providerDTO;
        }

        public static string GetShortCut(RouteDTO routeDTO)
        {
            if (routeDTO == null)
                return "";
            var shortCut = "";
            if (routeDTO.Lunes)
                shortCut += "L -";
            if (routeDTO.Martes)
                shortCut += " K -";
            if (routeDTO.Miercoles)
                shortCut += " M -";
            if (routeDTO.Jueves)
                shortCut += " J -";
            if (routeDTO.Viernes)
                shortCut += " V -";
            if (routeDTO.Sabado)
                shortCut += " S -";
            if (routeDTO.Domingo)
            {
                shortCut += " D";
            }
            else
            {
                var lastChar = shortCut.Length - 2;
                shortCut = shortCut.Substring(0, lastChar);
            }

            return shortCut;
        }

        public static List<ProviderDTO> FinishToGetAll(List<ProviderDTO> providersDTO, List<RouteDTO> routesDTO)
        {
            providersDTO.ForEach(x => x.Route = routesDTO.Find(y => y.RouteId == x.RouteId));
            foreach (var provider in providersDTO)
            {
                provider.Route = routesDTO.Find(y => y.RouteId == provider.RouteId);
                provider.RouteShortcut = GetShortCut(provider.Route);
            }
            return providersDTO;
        }
    }
}
