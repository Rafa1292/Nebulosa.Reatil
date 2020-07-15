using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        public bool KitchenMessage { get; set; }

        public int SidesQuantity { get; set; }

        public int TotalSales { get; set; }

        public int WarehouseQuantity { get; set; }

        [Required]
        [Range(1,10000000,ErrorMessage = "Debe seleccionar una subcategoria")]
        public int ProductSubCategoryId { get; set; }

        public virtual ProductSubCategoryDTO ProductSubCategoryDTO { get; set; }

        public List<ProductTaxDTO> Taxes { get; set; }

    }
}
