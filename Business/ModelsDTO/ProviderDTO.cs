using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProviderDTO
    {
        public int ProviderId { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public int Account { get; set; }

        public string Email { get; set; }

        public int RouteId { get; set; }

        public int PriceQuality { get; set; }

        public bool Delete { get; set; }

        public RouteDTO Route { get; set; }


    }
}
