using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Categories
{
    public class Finisher
    {
        public static ProductCategory FinishToInsert(ProductCategory productCategory)
        {
            productCategory.DateCreate = DateTime.Now;
            productCategory.DateUpdate = DateTime.Now;
            productCategory.UserCreate = "";//pendiente de implementar
            productCategory.UserUpdate = "";//pendiente de implementar

            return productCategory;
        }

        public static ProductCategory FinishToUpdate(ProductCategory productCategory)
        {
            productCategory.DateUpdate = DateTime.Now;
            productCategory.UserUpdate = "";//pendiente de implementar

            return productCategory;
        }
    }
}
