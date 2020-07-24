using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Brands
{
    public class MapperBrand
    {
        public static Brand MapFromDTO(BrandDTO brandDTO, Brand brand)
        {

            brand.BrandId = brandDTO.BrandId;
            brand.Name = brandDTO.Name;

            return brand;
        }

        public static BrandDTO MapToDTO(Brand brand)
        {
            BrandDTO brandDTO = new BrandDTO()
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            };

            return brandDTO;
        }

        public static List<BrandDTO> MapToDTO(List<Brand> brands)
        {
            List<BrandDTO> brandsDTO = new List<BrandDTO>();

            brands.ForEach(x => brandsDTO.Add(MapToDTO(x)));

            return brandsDTO;
        }
    }
}
