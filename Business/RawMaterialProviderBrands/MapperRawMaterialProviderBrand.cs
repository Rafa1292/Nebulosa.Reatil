using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviderBrands
{
    public class MapperRawMaterialProviderBrand
    {
        public static List<RawMaterialProviderBrand> MapFromDTO(List<RawMaterialProviderBrandDTO> rawMaterialProviderBrandsDTO)
        {
            List<RawMaterialProviderBrand> rawMaterialProviderBrands = new List<RawMaterialProviderBrand>();
            rawMaterialProviderBrandsDTO.ForEach(x => rawMaterialProviderBrands.Add(MapFromDTO(x)));

            return rawMaterialProviderBrands;
        }

        public static RawMaterialProviderBrand MapFromDTO(RawMaterialProviderBrandDTO rawMaterialProviderBrandDTO)
        {
            return new RawMaterialProviderBrand()
            {
                BrandId = rawMaterialProviderBrandDTO.BrandId,
                RawMaterialProviderBrandId = rawMaterialProviderBrandDTO.RawMaterialProviderBrandId,
                RawMaterialProviderId = rawMaterialProviderBrandDTO.RawMaterialProviderId
            };

        }

        public static RawMaterialProviderBrandDTO MapToDTO(RawMaterialProviderBrand rawMaterialProviderBrand)
        {
            RawMaterialProviderBrandDTO rawMaterialProviderBrandDTO = new RawMaterialProviderBrandDTO()
            {
                BrandId = rawMaterialProviderBrand.BrandId,
                RawMaterialProviderBrandId = rawMaterialProviderBrand.RawMaterialProviderBrandId,
                RawMaterialProviderId = rawMaterialProviderBrand.RawMaterialProviderId,
            };

            return rawMaterialProviderBrandDTO;
        }

        public static List<RawMaterialProviderBrandDTO> MapToDTO(List<RawMaterialProviderBrand> rawMaterialProviderBrands)
        {
            List<RawMaterialProviderBrandDTO> rawMaterialProviderBrandsDTO = new List<RawMaterialProviderBrandDTO>();

            rawMaterialProviderBrands.ForEach(x => rawMaterialProviderBrandsDTO.Add(MapToDTO(x)));

            return rawMaterialProviderBrandsDTO;
        }
    }
}
