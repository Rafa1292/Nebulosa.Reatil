using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Providers
{
    public class ValidateProvider
    {
        public static ObjectResponse<bool> ValidateToInsert(Provider provider, List<Provider> providers)
        {
            bool validateProviderName = String.IsNullOrWhiteSpace(provider.Name);

            if (validateProviderName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool NameExist = providers
                .Where(x => x.ProviderId != provider.ProviderId)
                .Select(x => x.Name.ToLower())
                .Contains(provider.Name.ToLower());

            if (NameExist)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");

            bool validateProviderPhone = provider.Phone > 0 ? true : false;

            if (!validateProviderPhone)
                return new ObjectResponse<bool>(false, "El numero debe ser valido");

            bool validateRouteId = provider.RouteId > 0 ? true : false;
            if (!validateRouteId)
                return new ObjectResponse<bool>(false, "Debe asignar una ruta");

            return new ObjectResponse<bool>(true, "Proveedor validado");
        }

        public static ObjectResponse<bool> ValidateToDelete(int providerId, List<RawMaterialProvider> rawMaterialProviders)
        {
            var rawMaterialRelationship = rawMaterialProviders.Select(x => x.ProviderId).Contains(providerId);
            if (rawMaterialRelationship)
                return new ObjectResponse<bool>(false, "Debes eliminar este proveedor de cualquier relacion con insumo antes de proceder con esta accion");


            return new ObjectResponse<bool>(true, "Proveedor validado");
        }

    }
}
