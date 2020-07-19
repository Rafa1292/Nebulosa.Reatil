using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProviderDTO
    {
        public int ProviderId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }

        [Range(1, 10000000, ErrorMessage = "Campo obligatorio")]
        public int Phone { get; set; }

        public int Account { get; set; }

        public string Email { get; set; }

        public int RouteId { get; set; }

        public int PriceQuality { get; set; }

        public bool Delete { get; set; }

        public string RouteShortcut { get; set; }

        public RouteDTO Route { get; set; }


    }
}
