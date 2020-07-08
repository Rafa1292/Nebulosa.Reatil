using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.SubCategories
{
    public class Mapper
    {
        public static ProductSubCategory MapFromDTO(ProductSubCategoryDTO productSubCategoryDTO, ProductSubCategory productSubCategory)
        {
            productSubCategory.ProductSubCategoryId = productSubCategoryDTO.ProductSubCategoryId;
            productSubCategory.Name = productSubCategoryDTO.Name;
            productSubCategory.ProductCategoryId = productSubCategoryDTO.ProductCategoryId;

            return productSubCategory;
        }

        public static ProductSubCategoryDTO MapToDTO(ProductSubCategory productSubCategory)
        {
            ProductSubCategoryDTO productSubCategoryDTO = new ProductSubCategoryDTO()
            {
                ProductSubCategoryId = productSubCategory.ProductSubCategoryId,
                Name = productSubCategory.Name,
                ProductCategoryId = productSubCategory.ProductCategoryId
            };

            return productSubCategoryDTO;
        }

        public static List<ProductSubCategoryDTO> MapToDTO(List<ProductSubCategory> productSubCategories)
        {
            List<ProductSubCategoryDTO> productSubCategoriesDTO = new List<ProductSubCategoryDTO>();

            productSubCategories.ForEach(x => productSubCategoriesDTO.Add(
                new ProductSubCategoryDTO()
                {
                    ProductSubCategoryId = x.ProductSubCategoryId,
                    Name = x.Name,
                    ProductCategoryId = x.ProductCategoryId
                }));

            return productSubCategoriesDTO;
        }
    }
}
