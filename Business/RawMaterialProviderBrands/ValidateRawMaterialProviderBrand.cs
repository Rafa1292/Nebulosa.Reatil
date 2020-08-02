using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.RawMaterialProviderBrands
{
    public class ValidateRawMaterialProviderBrand
    {
        public static ObjectResponse<bool> ValidateToInsert(RawMaterialProviderBrand rawMaterialProviderBrand)
        {
            bool validateBrandId = rawMaterialProviderBrand.BrandId > 0 ? true : false;
            if (!validateBrandId)
                return new ObjectResponse<bool>(false, "La marca no puede ser nula");

            bool validateRawMaterialProviderId = rawMaterialProviderBrand.RawMaterialProviderId > 0 ? true : false;
            if (!validateRawMaterialProviderId)
                return new ObjectResponse<bool>(false, "La marca debe estar asociada a un producto y un proveedor");

            return new ObjectResponse<bool>(true, "Relacion validada");
        }
    }
}
