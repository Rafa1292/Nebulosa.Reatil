using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviders
{
    public class MapperRawMaterialProvider
    {
        public static RawMaterialProvider MapFromDTO(RawMaterialProviderDTO rawMaterialProviderDTO, RawMaterialProvider rawMaterialProvider)
        {
            rawMaterialProvider.MeasureId = rawMaterialProviderDTO.MeasureId;
            rawMaterialProvider.Price = rawMaterialProviderDTO.Price;
            rawMaterialProvider.Quantity = rawMaterialProviderDTO.Quantity;
            rawMaterialProvider.RawMaterialId = rawMaterialProviderDTO.RawMaterialId;
            rawMaterialProvider.RawMaterialProviderId = rawMaterialProviderDTO.RawMaterialProviderId;
            rawMaterialProvider.Weight = rawMaterialProviderDTO.Weight;

            return rawMaterialProvider;
        }

        public static RawMaterialProviderDTO MapToDTO(RawMaterialProvider rawMaterialProvider)
        {
            RawMaterialProviderDTO rawMaterialProviderDTO = new RawMaterialProviderDTO()
            {
                MeasureId = rawMaterialProvider.MeasureId,
                Price = rawMaterialProvider.Price,
                Quantity = rawMaterialProvider.Quantity,
                RawMaterialId = rawMaterialProvider.RawMaterialId,
                RawMaterialProviderId = rawMaterialProvider.RawMaterialProviderId,
                Weight = rawMaterialProvider.Weight
            };

            return rawMaterialProviderDTO;
        }

        public static List<RawMaterialProviderDTO> MapToDTO(List<RawMaterialProvider> rawMaterialProviders)
        {
            List<RawMaterialProviderDTO> rawMaterialProvidersDTO = new List<RawMaterialProviderDTO>();

            rawMaterialProviders.ForEach(x => rawMaterialProvidersDTO.Add(
            new RawMaterialProviderDTO()
            {
                MeasureId = x.MeasureId,
                Price = x.Price,
                Quantity = x.Quantity,
                RawMaterialId = x.RawMaterialId,
                RawMaterialProviderId = x.RawMaterialProviderId,
                Weight = x.Weight
            }));

            return rawMaterialProvidersDTO;
        }
    }
}
