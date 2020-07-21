using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class RawMaterialProvider
    {
        public int RawMaterialProviderId { get; set; }

        public int ProviderId { get; set; }

        public int RawMaterialId { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }

        public int Quantity { get; set; }

        public int MeasureId { get; set; }

        public bool Delete { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
