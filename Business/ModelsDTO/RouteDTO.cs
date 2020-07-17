using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class RouteDTO
    {
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
