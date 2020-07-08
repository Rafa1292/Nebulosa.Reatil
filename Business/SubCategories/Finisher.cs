using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.SubCategories
{
    public class Finisher
    {
        public static ProductSubCategory FinishToInsert(ProductSubCategory productSubCategory)
        {
            productSubCategory.DateCreate = DateTime.Now;
            productSubCategory.DateUpdate = DateTime.Now;
            productSubCategory.UserCreate = "";//pendiente de implementar
            productSubCategory.UserUpdate = "";//pendiente de implementar

            return productSubCategory;
        }

        public static ProductSubCategory FinishToUpdate(ProductSubCategory productSubCategory)
        {
            productSubCategory.DateUpdate = DateTime.Now;
            productSubCategory.UserUpdate = "";//pendiente de implementar

            return productSubCategory;
        }

        public static ProductSubCategoryDTO FinishToGet(ProductSubCategoryDTO productSubCategoryDTO, ProductCategoryDTO productCategoryDTO)
        {
            productSubCategoryDTO.ProductCategoryDTO = productCategoryDTO;

            return productSubCategoryDTO;
        }

        public static List<ProductSubCategoryDTO> FinishToGetAll(List<ProductSubCategoryDTO> productSubCategoriesDTO, List<ProductCategoryDTO> productCategoriesDTO)
        {
            productSubCategoriesDTO.ForEach(x => x.ProductCategoryDTO = productCategoriesDTO.Find(y => y.ProductCategoryId == x.ProductCategoryId));
            return productSubCategoriesDTO;
        }
    }
}
