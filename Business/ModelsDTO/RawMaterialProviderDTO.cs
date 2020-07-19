using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class RawMaterialProviderDTO
    {
        public int RawMaterialProviderId { get; set; }

        public int ProviderId { get; set; }

        public int RawMaterialId { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }

        public int Quantity { get; set; }

        public virtual ProviderDTO ProviderDTO { get; set; }

        public virtual RawMaterialDTO RawMaterialDTO { get; set; }
    }
}
