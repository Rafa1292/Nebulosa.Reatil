using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Brands
{
    public class ValidateBrand
    {
        public static ObjectResponse<bool> ValidateToInsert(Brand brand, List<Brand> brands)
        {
            bool validateNullName = String.IsNullOrWhiteSpace(brand.Name);

            if (validateNullName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool NameExist = brands
                .Where(x => x.BrandId != brand.BrandId)
                .Select(x => x.Name.ToLower())
                .Contains(brand.Name.ToLower());

            if (NameExist)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");



            return new ObjectResponse<bool>(true, "Marca validada");
        }

        public static ObjectResponse<bool> ValidateToDelete(int brandId, List<RawMaterialProviderBrandDTO> rawMaterialProviderBrands)
        {
            var RawMaterialRelationship = rawMaterialProviderBrands.Select(x => x.BrandId).Contains(brandId);
            if (RawMaterialRelationship)
                return new ObjectResponse<bool>(false, "Debes eliminar los insumos asociados a esta marca antes de seguir con esta accion");


            return new ObjectResponse<bool>(true, "Marca validada");
        }
    }
}
