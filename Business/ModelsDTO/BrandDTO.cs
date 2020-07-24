using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class BrandDTO
    {
        public int BrandId { get; set; }

        public string Name { get; set; }

        public List<RawMaterialProviderBrandDTO> RawMaterialProvider { get; set; }

        public List<RawMaterialDTO> rawMaterialsDTO { get; set; }

        public List<ProviderDTO> providersDTO { get; set; }

    }
}
