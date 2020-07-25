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
        public static List<RawMaterialProviderBrand> FinishToInsert(List<RawMaterialProviderBrand> rawMaterialProviderBrands, int rawMaterialProviderId)
        {
            foreach (var rawMaterialProviderBrand in rawMaterialProviderBrands)
            {
                rawMaterialProviderBrand.RawMaterialProviderId = rawMaterialProviderId;
                rawMaterialProviderBrand.DateCreate = DateTime.Now;
                rawMaterialProviderBrand.DateUpdate = DateTime.Now;
                rawMaterialProviderBrand.UserCreate = "";//pendiente de implementar
                rawMaterialProviderBrand.UserUpdate = "";//pendiente de implementar
            }


            return rawMaterialProviderBrands;

        }

        public static List<RawMaterialProviderBrand> FinishToUpdate(List<RawMaterialProviderBrand> rawMaterialProviderBrands)
        {
            foreach (var rawMaterialProviderBrand in rawMaterialProviderBrands)
            {
                rawMaterialProviderBrand.DateUpdate = DateTime.Now;
                rawMaterialProviderBrand.UserUpdate = "";//pendiente de implementar
            }
            return rawMaterialProviderBrands;
        }

        public static List<RawMaterialProviderBrandDTO> FinishToGetAll(List<RawMaterialProviderBrandDTO> rawMaterialProviderBrandsDTO, List<BrandDTO> brandsDTO)
        {
            rawMaterialProviderBrandsDTO.ForEach(x => x.Brand = brandsDTO.FirstOrDefault(y => y.BrandId == x.BrandId));

            return rawMaterialProviderBrandsDTO;
        }
    }
}
