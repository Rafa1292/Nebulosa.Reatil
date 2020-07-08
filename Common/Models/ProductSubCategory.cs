using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class ProductSubCategory
    {
        [Key]
        public int ProductSubCategoryId { get; set; }

        [MaxLength(20, ErrorMessage = "Maximo {0} caracteres")]
        public string Name { get; set; }

        public bool Delete { get; set; }

        public int ProductCategoryId { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
