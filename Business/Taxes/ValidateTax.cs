using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Taxes
{
    public class ValidateTax
    {
        public static ObjectResponse<bool> ValidateToInsert(Tax tax)
        {
            bool validateTaxName = tax.Name != null ? true : false;

            if (!validateTaxName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");


            return new ObjectResponse<bool>(true, "Impuesto validado");
        }

        public static ObjectResponse<bool> ValidateToDelete(int taxId, List<ProductTaxDTO> productTaxes)
        {
            var productsRelationship = productTaxes.Select(x => x.TaxId).Contains(taxId);
            if (productsRelationship)
                return new ObjectResponse<bool>(false, "Debes eliminar los productos asociados antes de seguir con esta accion");


            return new ObjectResponse<bool>(true, "Impuesto validado");
        }
    }
}
