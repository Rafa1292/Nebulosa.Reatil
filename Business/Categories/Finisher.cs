using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Categories
{
    public class Finisher
    {
        public static ProductCategory FinishToInsert(ProductCategory productCategory)
        {
            productCategory.DateCreate = DateTime.Now;
            productCategory.DateUpdate = DateTime.Now;
            productCategory.UserCreate = "";//pendiente de implementar
            productCategory.UserUpdate = "";//pendiente de implementar

            return productCategory;
        }

        public static ProductCategory FinishToUpdate(ProductCategory productCategory)
        {
            productCategory.DateUpdate = DateTime.Now;
            productCategory.UserUpdate = "";//pendiente de implementar

            return productCategory;
        }

        public static ProductCategoryDTO FinishToGet(ProductCategoryDTO productCategoryDTO, List<ProductSubCategoryDTO> productSubCategoriesDTO)
        {
            productCategoryDTO.SubCategoriesDTO = productSubCategoriesDTO.Where(x => x.ProductCategoryId == productCategoryDTO.ProductCategoryId).ToList();

            return productCategoryDTO;
        }

        public static List<ProductCategoryDTO> FinishToGetAll(List<ProductCategoryDTO> productCategoriesDTO, List<ProductSubCategoryDTO> productSubCategoriesDTO)
        {
            productCategoriesDTO.ForEach(x => x.SubCategoriesDTO = productSubCategoriesDTO.Where(y => y.ProductCategoryId == x.ProductCategoryId).ToList());
            return productCategoriesDTO;
        }
    }
}
