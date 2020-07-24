using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Measure
    {
        public int MeasureId { get; set; }

        public string Name { get; set; }

        public bool Delete { get; set; }

        public string UserCreate { get; set; }

        public string UserUpdate { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
