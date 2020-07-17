using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Providers
{
    public class MapperProvider
    {
        public static Provider MapFromDTO(ProviderDTO providerDTO, Provider provider)
        {
            provider.Account = providerDTO.Account;
            provider.Email = providerDTO.Email;
            provider.Name = providerDTO.Name;
            provider.Phone = providerDTO.Phone;
            provider.PriceQuality = providerDTO.PriceQuality;
            provider.ProviderId = providerDTO.ProviderId;
            provider.RouteId = providerDTO.RouteId;

            return provider;
        }

        public static ProviderDTO MapToDTO(Provider provider)
        {
            ProviderDTO providerDTO = new ProviderDTO()
            {
                Account = provider.Account,
                Email = provider.Email,
                Name = provider.Name,
                Phone = provider.Phone,
                PriceQuality = provider.PriceQuality,
                ProviderId = provider.ProviderId,
                RouteId = provider.RouteId
            };

            return providerDTO;
        }

        public static List<ProviderDTO> MapToDTO(List<Provider> providers)
        {
            List<ProviderDTO> providersDTO = new List<ProviderDTO>();

            providers.ForEach(x => providersDTO.Add(
                new ProviderDTO()
                {
                    Account = x.Account,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                    PriceQuality = x.PriceQuality,
                    ProviderId = x.ProviderId,
                    RouteId = x.RouteId
                }));

            return providersDTO;
        }
    }
}
