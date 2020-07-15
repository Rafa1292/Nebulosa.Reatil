using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductCategoryDTO
    {
        public int ProductCategoryId { get; set; }

        public string Name { get; set; }

        public List<ProductSubCategoryDTO> SubCategoriesDTO { get; set; }
    }
}
