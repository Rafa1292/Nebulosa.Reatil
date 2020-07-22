using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviders
{
    public class Finisher
    {
        public static RawMaterialProvider FinishToInsert(RawMaterialProvider rawMaterialProvider)
        {
            rawMaterialProvider.DateCreate = DateTime.Now;
            rawMaterialProvider.DateUpdate = DateTime.Now;
            rawMaterialProvider.UserCreate = "";//pendiente de implementar
            rawMaterialProvider.UserUpdate = "";//pendiente de implementar

            return rawMaterialProvider;
        }

        public static RawMaterialProvider FinishToUpdate(RawMaterialProvider rawMaterialProvider)
        {
            rawMaterialProvider.DateUpdate = DateTime.Now;
            rawMaterialProvider.UserUpdate = "";//pendiente de implementar

            return rawMaterialProvider;
        }
    }
}
