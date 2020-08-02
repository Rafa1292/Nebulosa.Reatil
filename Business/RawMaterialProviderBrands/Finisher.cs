using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.RawMaterialProviderBrands
{
    public class Finisher
    {
        public static RawMaterialProviderBrand FinishToDatabase(RawMaterialProviderBrand rawMaterialProviderBrand, int rawMaterialProviderId)
        {
            if (!(rawMaterialProviderBrand.DateCreate > new DateTime(1 / 1 / 1)))
            {
                rawMaterialProviderBrand.DateCreate = DateTime.Now;
                rawMaterialProviderBrand.UserCreate = "";//pendiente de implementar
            }

            rawMaterialProviderBrand.RawMaterialProviderId = rawMaterialProviderId;
            rawMaterialProviderBrand.DateUpdate = DateTime.Now;
            rawMaterialProviderBrand.UserUpdate = "";//pendiente de implementar

            return rawMaterialProviderBrand;

        }

        public static List<RawMaterialProviderBrandDTO> FinishToGetAll(List<RawMaterialProviderBrandDTO> rawMaterialProviderBrandsDTO, List<BrandDTO> brandsDTO)
        {
            rawMaterialProviderBrandsDTO.ForEach(x => x.Brand = brandsDTO.FirstOrDefault(y => y.BrandId == x.BrandId));

            return rawMaterialProviderBrandsDTO;
        }
    }
}
