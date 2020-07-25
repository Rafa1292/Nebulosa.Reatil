using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class RawMaterialProviderBrand
    {
        [Key]
        public int RawMaterialProviderBrandId { get; set; }

        public int RawMaterialProviderId { get; set; }

        public int BrandId { get; set; }

        public bool Delete { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
