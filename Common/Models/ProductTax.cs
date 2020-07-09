using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class ProductTax
    {
        [Key]
        public int ProductTaxId { get; set; }

        public int ProductId { get; set; }

        public bool Delete { get; set; }

        public int TaxId { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
