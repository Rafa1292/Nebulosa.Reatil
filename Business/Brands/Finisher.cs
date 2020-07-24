using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Brands
{
    public class Finisher
    {
        public static Brand FinishToInsert(Brand brand)
        {
            brand.DateCreate = DateTime.Now;
            brand.DateUpdate = DateTime.Now;
            brand.UserCreate = "";//pendiente de implementar
            brand.UserUpdate = "";//pendiente de implementar

            return brand;
        }

        public static Brand FinishToUpdate(Brand brand)
        {
            brand.DateUpdate = DateTime.Now;
            brand.UserUpdate = "";//pendiente de implementar

            return brand;
        }

        public static BrandDTO FinishToGet(BrandDTO brand, List<RawMaterialProviderBrandDTO> rawMaterialProviderBrands)
        {
            var providers = rawMaterialProviderBrands.Where(x => x.BrandId == brand.BrandId).Select(x => x.RawMaterialProvider.ProviderDTO).ToList();
            var rawMaterials = rawMaterialProviderBrands.Where(x => x.BrandId == brand.BrandId).Select(x => x.RawMaterialProvider.RawMaterialDTO).ToList();

            brand.RawMaterialProvider = rawMaterialProviderBrands;
            brand.providersDTO = providers;
            brand.rawMaterialsDTO = rawMaterials;

            return brand;
        }

        public static List<BrandDTO> FinishToGetAll(List<BrandDTO> brands, List<RawMaterialProviderBrandDTO> rawMaterialProviderBrands)
        {
            List<BrandDTO> finishedBrands = new List<BrandDTO>();
            foreach (var brand in brands)
            {
                finishedBrands.Add(FinishToGet(brand, rawMaterialProviderBrands));
            }

            return finishedBrands;
        }
    }
}
