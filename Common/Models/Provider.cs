using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public int Account { get; set; }

        public string Email { get; set; }

        public int RouteId { get; set; }

        public int PriceQuality { get; set; }

        public bool Delete { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
