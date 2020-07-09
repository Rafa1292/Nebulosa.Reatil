using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Taxes
{
    public class Finisher
    {
        public static Tax FinishToInsert(Tax tax)
        {
            tax.DateCreate = DateTime.Now;
            tax.DateUpdate = DateTime.Now;
            tax.UserCreate = "";//pendiente de implementar
            tax.UserUpdate = "";//pendiente de implementar

            return tax;
        }

        public static Tax FinishToUpdate(Tax tax)
        {
            tax.DateUpdate = DateTime.Now;
            tax.UserUpdate = "";//pendiente de implementar

            return tax;
        }
    }
}
