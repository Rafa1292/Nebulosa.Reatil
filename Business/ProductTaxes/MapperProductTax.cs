using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProductTaxes
{
    class MapperProductTax
    {
        public static ProductTax MapFromDTO(ProductTaxDTO productTaxDTO, ProductTax productTax)
        {
            productTax.ProductTaxId = productTaxDTO.ProductTaxId;
            productTax.ProductId = productTaxDTO.ProductId;
            productTax.TaxId = productTaxDTO.TaxId;

            return productTax;
        }

        public static ProductTaxDTO MapToDTO(ProductTax productTax)
        {
            ProductTaxDTO productTaxDTO = new ProductTaxDTO()
            {
                ProductTaxId = productTax.ProductTaxId,
                TaxId = productTax.TaxId,
                ProductId = productTax.ProductId
            };

            return productTaxDTO;
        }

        public static List<ProductTaxDTO> MapToDTO(List<ProductTax> productTax)
        {
            List<ProductTaxDTO> productTaxesDTO = new List<ProductTaxDTO>();

            productTax.ForEach(x => productTaxesDTO.Add(
                new ProductTaxDTO()
                {
                    ProductTaxId = x.ProductTaxId,
                    ProductId = x.ProductId,
                    TaxId = x.TaxId
                }));

            return productTaxesDTO;
        }
    }
}
