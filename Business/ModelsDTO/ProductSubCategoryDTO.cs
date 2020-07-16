using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductSubCategoryDTO
    {
        public int ProductSubCategoryId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }

        [Range(1, 10000000, ErrorMessage = "Debe seleccionar una categoria")]
        public int ProductCategoryId { get; set; }

        public ProductCategoryDTO ProductCategoryDTO { get; set; }

    }
}
