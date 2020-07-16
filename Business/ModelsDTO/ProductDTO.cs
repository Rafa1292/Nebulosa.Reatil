using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public bool KitchenMessage { get; set; }

        public int SidesQuantity { get; set; }

        public int TotalSales { get; set; }

        public int WarehouseQuantity { get; set; }

        [Range(1,10000000,ErrorMessage = "Debe seleccionar una subCategoria")]
        public int ProductSubCategoryId { get; set; }

        public virtual ProductSubCategoryDTO ProductSubCategoryDTO { get; set; }

        public List<ProductTaxDTO> Taxes { get; set; }

    }
}
