using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProductTaxes
{
    public class Finisher
    {
        public static ProductTax FinishToInsert(ProductTax productTax)
        {
            productTax.DateCreate = DateTime.Now;
            productTax.DateUpdate = DateTime.Now;
            productTax.UserCreate = "";//pendiente de implementar
            productTax.UserUpdate = "";//pendiente de implementar

            return productTax;
        }

        public static ProductTax FinishToUpdate(ProductTax productTax)
        {
            productTax.DateUpdate = DateTime.Now;
            productTax.UserUpdate = "";//pendiente de implementar

            return productTax;
        }
    }
}
