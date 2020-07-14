using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Proucts
{
    public class MapperProduct
    {
        public static Product MapFromDTO(ProductDTO productDTO, Product product)
        {
            product.ProductId = productDTO.ProductId;
            product.Name = productDTO.Name;
            product.Cost = productDTO.Cost;
            product.KitchenMessage = productDTO.KitchenMessage;
            product.Price = productDTO.Price;
            product.SidesQuantity = productDTO.SidesQuantity;
            product.TotalSales = productDTO.TotalSales;
            product.WarehouseQuantity = productDTO.WarehouseQuantity;
            product.ProductSubCategoryId = productDTO.ProductSubCategoryId;

            return product;
        }

        public static ProductDTO MapToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Cost = product.Cost,
                KitchenMessage = product.KitchenMessage,
                Price = product.Price,
                SidesQuantity = product.SidesQuantity,
                TotalSales = product.TotalSales,
                WarehouseQuantity = product.WarehouseQuantity,
                ProductSubCategoryId = product.ProductSubCategoryId
            };

            return productDTO;
        }

        public static List<ProductDTO> MapToDTO(List<Product> products)
        {
            List<ProductDTO> productsDTO = new List<ProductDTO>();

            products.ForEach(x => productsDTO.Add(
                new ProductDTO()
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Cost = x.Cost,
                    KitchenMessage = x.KitchenMessage,
                    Price = x.Price,
                    SidesQuantity = x.SidesQuantity,
                    TotalSales = x.TotalSales,
                    WarehouseQuantity = x.WarehouseQuantity,
                    ProductSubCategoryId = x.ProductSubCategoryId

                }));

            return productsDTO;
        }
    }
}
