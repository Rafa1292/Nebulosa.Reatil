using Business.ModelsDTO;
using Common.Models;
using System.Collections.Generic;

namespace Business.RawMaterialProviders
{
    public class MapperRawMaterialProvider
    {
        public static RawMaterialProvider MapFromDTO(RawMaterialProviderDTO rawMaterialProviderDTO, RawMaterialProvider rawMaterialProvider)
        {
            rawMaterialProvider.ProviderId = rawMaterialProviderDTO.ProviderId;
            rawMaterialProvider.MeasureId = rawMaterialProviderDTO.MeasureId;
            rawMaterialProvider.Price = rawMaterialProviderDTO.Price;
            rawMaterialProvider.Quantity = rawMaterialProviderDTO.Quantity;
            rawMaterialProvider.RawMaterialId = rawMaterialProviderDTO.RawMaterialId;
            rawMaterialProvider.RawMaterialProviderId = rawMaterialProviderDTO.RawMaterialProviderId;
            rawMaterialProvider.Weight = rawMaterialProviderDTO.Weight;
            rawMaterialProvider.CurrentProvider = rawMaterialProviderDTO.CurrentProvider;

            return rawMaterialProvider;
        }

        public static RawMaterialProviderDTO MapToDTO(RawMaterialProvider rawMaterialProvider)
        {
            RawMaterialProviderDTO rawMaterialProviderDTO = new RawMaterialProviderDTO()
            {
                ProviderId = rawMaterialProvider.ProviderId,
                MeasureId = rawMaterialProvider.MeasureId,
                Price = rawMaterialProvider.Price,
                Quantity = rawMaterialProvider.Quantity,
                RawMaterialId = rawMaterialProvider.RawMaterialId,
                RawMaterialProviderId = rawMaterialProvider.RawMaterialProviderId,
                Weight = rawMaterialProvider.Weight,
                CurrentProvider = rawMaterialProvider.CurrentProvider
            };

            return rawMaterialProviderDTO;
        }

        public static List<RawMaterialProviderDTO> MapToDTO(List<RawMaterialProvider> rawMaterialProviders)
        {
            List<RawMaterialProviderDTO> rawMaterialProvidersDTO = new List<RawMaterialProviderDTO>();

            rawMaterialProviders.ForEach(x => rawMaterialProvidersDTO.Add(MapToDTO(x)));

            return rawMaterialProvidersDTO;
        }
    }
}
