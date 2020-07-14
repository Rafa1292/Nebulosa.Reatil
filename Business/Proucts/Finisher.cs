using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Proucts
{
    public class Finisher
    {
        public static Product FinishToInsert(Product product)
        {
            product.DateCreate = DateTime.Now;
            product.DateUpdate = DateTime.Now;
            product.UserCreate = "";//pendiente de implementar
            product.UserUpdate = "";//pendiente de implementar

            return product;
        }

        public static Product FinishToUpdate(Product product)
        {
            product.DateUpdate = DateTime.Now;
            product.UserUpdate = "";//pendiente de implementar

            return product;
        }

        public static ProductDTO FinishToGet(ProductDTO productDTO, ProductSubCategoryDTO productSubCategoryDTO, List<ProductTaxDTO> taxes)
        {
            productDTO.ProductSubCategoryDTO = productSubCategoryDTO;
            productDTO.Taxes = taxes.Where(x => x.ProductId == productDTO.ProductId).ToList();

            return productDTO;
        }

        public static List<ProductDTO> FinishToGetAll(List<ProductDTO> productsDTO ,List<ProductSubCategoryDTO> productSubCategoriesDTO, List<ProductTaxDTO> taxesDTO)
        {
            productsDTO.ForEach(x => x.Taxes = taxesDTO.Where(y => y.ProductId == x.ProductId).ToList());
            productsDTO.ForEach(x => x.ProductSubCategoryDTO = productSubCategoriesDTO.Find(y => y.ProductSubCategoryId == x.ProductSubCategoryId));

            return productsDTO;
        }
    }
}
