using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class PreparationItem
    {
        public int PreparationItemId { get; set; }

        public int Quantiy { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }

        public bool Delete { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }

        public int PreparationId { get; set; }

        public int MeasureId { get; set; }

        public int RawMaterialId { get; set; }

    }
}
