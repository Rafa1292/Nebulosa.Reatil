using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        public bool Lunes { get; set; }

        public bool Martes { get; set; }

        public bool Miercoles { get; set; }

        public bool Jueves { get; set; }

        public bool Viernes { get; set; }

        public bool Sabado { get; set; }

        public bool Domingo { get; set; }

        public bool Delete { get; set; }



    }
}
