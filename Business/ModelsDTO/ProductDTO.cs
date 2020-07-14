using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        public bool KitchenMessage { get; set; }

        public int SidesQuantity { get; set; }

        public int TotalSales { get; set; }

        public int WarehouseQuantity { get; set; }

        public int ProductSubCategoryId { get; set; }

        public virtual ProductSubCategoryDTO ProductSubCategoryDTO { get; set; }

        public List<ProductTaxDTO> Taxes { get; set; }

    }
}
