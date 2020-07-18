using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Categories
{
    public class ValidateCategory
    {
        public static ObjectResponse<bool> ValidateToInsert(ProductCategory category, List<ProductCategory> categories)
        {
            bool validateNullName = category.Name != null ? true : false;

            if (!validateNullName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool NameExist = categories
                .Where(x => x.ProductCategoryId != category.ProductCategoryId)
                .Select(x => x.Name.ToLower())
                .Contains(category.Name.ToLower());

            if (NameExist)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");



            return new ObjectResponse<bool>(true, "Categoria validada");
        }

        public static ObjectResponse<bool> ValidateToDelete(int categoryId, List<ProductSubCategoryDTO> subCategories)
        {
            var subCategoriesRelationship = subCategories.Select(x => x.ProductCategoryId).Contains(categoryId);
            if (subCategoriesRelationship)
                return new ObjectResponse<bool>(false, "Debes eliminar las subCategorias asociadas antes de seguir con esta accion");


            return new ObjectResponse<bool>(true, "Categoria validada");
        }

    }
}
