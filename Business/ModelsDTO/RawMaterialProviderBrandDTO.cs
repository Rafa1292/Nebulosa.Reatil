using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class RawMaterialProviderBrandDTO
    {
        public int RawMaterialProviderBrandId { get; set; }

        public int RawMaterialProviderId { get; set; }

        public int BrandId { get; set; }

        public BrandDTO Brand { get; set; }

        public RawMaterialProviderDTO RawMaterialProvider { get; set; }
    }
}
