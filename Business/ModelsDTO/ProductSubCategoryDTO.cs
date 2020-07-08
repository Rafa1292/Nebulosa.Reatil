using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductSubCategoryDTO
    {
        public int ProductSubCategoryId { get; set; }

        public string Name { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategoryDTO ProductCategoryDTO { get; set; }

    }
}
