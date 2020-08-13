using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class PreparationDTO
    {
        public int PreparationId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public int Weight { get; set; }

        public List<PreparationItemDTO> PreparationItemsDTO { get; set; }
    }
}
