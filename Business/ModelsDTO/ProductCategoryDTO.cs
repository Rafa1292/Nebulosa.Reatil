using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductCategoryDTO
    {
        public int ProductCategoryId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }

        public List<ProductSubCategoryDTO> SubCategoriesDTO { get; set; }
    }
}
