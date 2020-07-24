using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviders
{
    public class ValidateRawMaterialProvider
    {
        public static ObjectResponse<bool> ValidateToInsert(List<RawMaterialProvider> rawMaterialProviders)
        {
            foreach (var rawMaterialProvider in rawMaterialProviders)
            {
                bool validateProviderId = rawMaterialProvider.ProviderId > 0 ? true : false;
                if (!validateProviderId)
                    return new ObjectResponse<bool>(false, "El proveedor no puede ser nulo");

                bool validateRawMaterialId = rawMaterialProvider.RawMaterialId > 0 ? true : false;
                if (!validateRawMaterialId)
                    return new ObjectResponse<bool>(false, "El producto no puede ser nulo");

                bool validateMeasureId = rawMaterialProvider.MeasureId > 0 ? true : false;
                if (!validateMeasureId)
                    return new ObjectResponse<bool>(false, "La medida no puede ser nula");

                bool validatePrice = rawMaterialProvider.Price > 0 ? true : false;
                if (!validatePrice)
                    return new ObjectResponse<bool>(false, "El precio no puede ser nulo o cero");

                bool validateWeight = rawMaterialProvider.Weight > 0 ? true : false;
                if (!validateWeight)
                    return new ObjectResponse<bool>(false, "El peso no puede ser nulo o cero");

                bool validateQuantity = rawMaterialProvider.Quantity > 0 ? true : false;
                if (!validateQuantity)
                    return new ObjectResponse<bool>(false, "La cantidad no puede ser nula o cero");
            }

            return new ObjectResponse<bool>(true, "Relacion validada");
        }

    }
}
