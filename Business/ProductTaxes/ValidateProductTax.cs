using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProductTaxes
{
    public class ValidateProductTax
    {
        public static ObjectResponse<bool> ValidateToInsert(ProductTax productTax)
        {
            bool validateNullTaxId = productTax.TaxId > 0 ? true : false;

            if (!validateNullTaxId)
                return new ObjectResponse<bool>(false, "El impuesto no puede ser nulo");

            bool validateNullProductId = productTax.ProductId > 0 ? true : false;

            if (!validateNullProductId)
                return new ObjectResponse<bool>(false, "El producto no puede ser nulo");

            return new ObjectResponse<bool>(true, "Impuesto validado");
        }
    }
}
