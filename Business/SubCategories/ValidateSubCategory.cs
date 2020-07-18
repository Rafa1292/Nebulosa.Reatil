using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.SubCategories
{
    public class ValidateSubCategory
    {
        public static ObjectResponse<bool> ValidateToInsert(ProductSubCategory subCategory, List<ProductSubCategory> subCategories)
        {
            bool validateNullName = subCategory.Name != null ? true : false;

            if (!validateNullName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool validateNullCategoryId = subCategory.ProductCategoryId > 0 ? true : false;

            if (!validateNullCategoryId)
                return new ObjectResponse<bool>(false, "La categoria no puede ser nula");

            bool NameExist = subCategories
                .Where(x => x.ProductSubCategoryId != subCategory.ProductSubCategoryId && x.ProductCategoryId == subCategory.ProductCategoryId)
                .Select(x => x.Name.ToLower())
                .Contains(subCategory.Name.ToLower());

            if (NameExist)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");



            return new ObjectResponse<bool>(true, "SubCategoria validada");
        }

        public static ObjectResponse<bool> ValidateToDelete(int subCategoryId, List<Product> products)
        {
            var productsRelationship = products.Select(x => x.ProductSubCategoryId).Contains(subCategoryId);
            if (productsRelationship)
                return new ObjectResponse<bool>(false, "Debes eliminar los productos asociados antes de seguir con esta accion");


            return new ObjectResponse<bool>(true, "SubCategoria validada");
        }
    }
}
