using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProductTaxes
{
    public class Finisher
    {
        public static List<ProductTax> FinishToInsert(List<ProductTax> productTaxes)
        {
            foreach (var productTax in productTaxes)
            {
                productTax.DateCreate = DateTime.Now;
                productTax.DateUpdate = DateTime.Now;
                productTax.UserCreate = "";//pendiente de implementar
                productTax.UserUpdate = "";//pendiente de implementar
            }


            return productTaxes;
        }

        public static List<ProductTax> FinishToUpdate(List<ProductTax> productTaxes)
        {
            foreach (var productTax in productTaxes)
            {
                productTax.DateUpdate = DateTime.Now;
                productTax.UserUpdate = "";//pendiente de implementar
            }


            return productTaxes;
        }
    }
}
