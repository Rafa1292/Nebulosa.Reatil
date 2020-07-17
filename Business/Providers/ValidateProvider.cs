using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Providers
{
    public class ValidateProvider
    {
        public static ObjectResponse<bool> ValidateToInsert(Provider provider)
        {
            bool validateProviderName = provider.Name != null ? true : false;

            if (!validateProviderName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool validateProviderPhone = provider.Phone > 0 ? true : false;

            if (!validateProviderPhone)
                return new ObjectResponse<bool>(false, "El numero debe ser valido");

            bool validateRouteId= provider.RouteId > 0 ? true : false;
            if (!validateRouteId)
                return new ObjectResponse<bool>(false, "Debe asignar una ruta");

            return new ObjectResponse<bool>(true, "Proveedor validado");
        }
    }
}
