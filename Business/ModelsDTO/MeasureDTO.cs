using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ModelsDTO
{
    public class MeasureDTO
    {
        public int MeasureId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }
    }
}
