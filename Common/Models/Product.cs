using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        public bool KitchenMessage { get; set; }

        public int SidesQuantity { get; set; }

        public int TotalSales { get; set; }

        public int WarehouseQuantity { get; set; }

        public int ProductSubCategoryId { get; set; }

        public bool Delete { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
