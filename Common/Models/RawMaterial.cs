using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class RawMaterial
    {
        public int RawMaterialId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public DateTime LastPurchase { get; set; }

        public int ProviderId { get; set; }

        public bool Delete { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
