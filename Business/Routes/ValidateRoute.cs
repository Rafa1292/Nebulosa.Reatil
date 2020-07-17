using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Routes
{
    public class ValidateRoute
    {
        public static ObjectResponse<bool> ValidateToInsert(Route route)
        {

            if (route.Lunes || route.Martes || route.Miercoles || route.Jueves || route.Viernes || route.Sabado || route.Domingo)
                return new ObjectResponse<bool>(true, "Ruta validada");



            return new ObjectResponse<bool>(false, "Debe escoger almenos un dia");
        }
    }
}
