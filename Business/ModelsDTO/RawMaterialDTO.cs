using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class RawMaterialDTO
    {
        public int RawMaterialId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }

        public int Stock { get; set; }

        public DateTime LastPurchase { get; set; }

        public int ProviderId { get; set; }

        public decimal CurrentPrice { get; set; }

        public int CurrentWeight { get; set; }

        public int CurreentQuantity { get; set; }

        public List<RawMaterialProviderDTO> rawMaterialProvidersDTO { get; set; }


    }
}
