using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProductTaxes
{
    class MapperProductTax
    {
        //mapear  en lista
        public static List<ProductTax> MapFromDTO(List<ProductTaxDTO> productTaxesDTO, int productId)
        {
            List<ProductTax> productTaxes = new List<ProductTax>();

            foreach (var productTaxDTO in productTaxesDTO)
            {
                ProductTax productTax = new ProductTax()
                {
                    ProductTaxId = productTaxDTO.ProductTaxId,
                    ProductId = productId,
                    TaxId = productTaxDTO.TaxId
                };
                productTaxes.Add(productTax);
            }

            return productTaxes;
        }

        public static List<ProductTaxDTO> MapToDTO(List<ProductTax> productTaxes)
        {
            List<ProductTaxDTO> productTaxesDTO = new List<ProductTaxDTO>();

            foreach (var productTax in productTaxes)
            {
                ProductTaxDTO productTaxDTO = new ProductTaxDTO()
                {
                    ProductTaxId = productTax.ProductTaxId,
                    ProductId = productTax.ProductId,
                    TaxId = productTax.TaxId
                };
                productTaxesDTO.Add(productTaxDTO);
            }

            return productTaxesDTO;
        }
    }
}
