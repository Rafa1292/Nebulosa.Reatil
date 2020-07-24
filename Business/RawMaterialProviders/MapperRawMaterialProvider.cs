using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviders
{
    public class MapperRawMaterialProvider
    {
        public static List<RawMaterialProvider> MapFromDTO(List<RawMaterialProviderDTO> rawMaterialProvidersDTO)
        {
            List<RawMaterialProvider> rawMaterialProviders = new List<RawMaterialProvider>();
            rawMaterialProvidersDTO.ForEach(x => rawMaterialProviders.Add(
                new RawMaterialProvider()
                {
                    ProviderId = x.ProviderId,
                    MeasureId = x.MeasureId,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    RawMaterialId = x.RawMaterialId,
                    RawMaterialProviderId = x.RawMaterialProviderId,
                    Weight = x.Weight
                }
                ));


            return rawMaterialProviders;
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
