using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class PreparationItemDTO
    {
        public int PreparationItemId { get; set; }

        public int Quantiy { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }

        public int PreparationId { get; set; }

        public int MeasureId { get; set; }

        public int RawMaterialId { get; set; }

        public MeasureDTO MeasureDTO { get; set; }

        public RawMaterialDTO RawMaterialDTO { get; set; }

    }
}
