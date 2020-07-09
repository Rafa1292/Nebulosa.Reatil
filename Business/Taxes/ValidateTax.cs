using Common;
using Common.Models;
using System;
using System.Collections.Generic;
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
    }
}
