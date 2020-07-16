using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class TaxDTO
    {
        public int TaxId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }

        [Range(1, 10000000, ErrorMessage = "Debe indicar un porcentage")]
        public int Percentage { get; set; }
    }
}
