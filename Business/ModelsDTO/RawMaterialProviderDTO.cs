using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class RawMaterialProviderDTO
    {
        public int RawMaterialProviderId { get; set; }

        public int RawMaterialProviderBrandId { get; set; }

        public bool CurrentProvider { get; set; }

        [Range(1, 10000000, ErrorMessage = "Debe seleccionar una subCategoria")]
        public int ProviderId { get; set; }

        public int RawMaterialId { get; set; }

        public int Price { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public int Weight { get; set; }

        public int Quantity { get; set; }

        [Range(1, 10000000, ErrorMessage = "Debe seleccionar una subCategoria")]
        public int MeasureId { get; set; }

        public MeasureDTO MeasureDTO { get; set; }

        public virtual ProviderDTO ProviderDTO { get; set; }

        public virtual RawMaterialDTO RawMaterialDTO { get; set; }

        public virtual RawMaterialProviderBrandDTO RawMaterialProviderBrandDTO { get; set; }

    }
}
