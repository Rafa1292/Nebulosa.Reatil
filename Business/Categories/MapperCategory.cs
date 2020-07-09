using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;

namespace Business.Categories
{
    public class MapperCategory
    {
        public static ProductCategory MapFromDTO(ProductCategoryDTO productCategoryDTO, ProductCategory productCategory)
        {
            productCategory.ProductCategoryId = productCategoryDTO.ProductCategoryId;
            productCategory.Name = productCategoryDTO.Name;
     
            return productCategory;
        }

        public static ProductCategoryDTO MapToDTO(ProductCategory productCategory)
        {
            ProductCategoryDTO productCategoryDTO = new ProductCategoryDTO()
            {
                ProductCategoryId = productCategory.ProductCategoryId,
                Name = productCategory.Name
            };

            return productCategoryDTO;
        }

        public static List<ProductCategoryDTO> MapToDTO(List<ProductCategory> productCategories)
        {
            List<ProductCategoryDTO> productCategoriesDTO = new List<ProductCategoryDTO>();

            productCategories.ForEach(x => productCategoriesDTO.Add(
                new ProductCategoryDTO()
                {
                    ProductCategoryId = x.ProductCategoryId,
                    Name = x.Name
                }));

            return productCategoriesDTO;
        }
    }
}
