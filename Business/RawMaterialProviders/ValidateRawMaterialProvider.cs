using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.RawMaterialProviders
{
    public class ValidateRawMaterialProvider
    {
        public static ObjectResponse<bool> ValidateToInsert(RawMaterialProvider rawMaterialProvider)
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


            return new ObjectResponse<bool>(true, "Relacion validada");
        }

        public static ObjectResponse<bool> ValidateDontRepeatBrandByProvider(RawMaterialProviderDTO rawMaterialProviderDTO, List<RawMaterialProviderDTO> rawMaterialProvidersDTO)
        {
            var rawMaterialWithSameProvider = rawMaterialProvidersDTO.Where(x => x.ProviderId == rawMaterialProviderDTO.ProviderId).ToList();
            var rawMaterialWithSameProviderSameBrand = rawMaterialWithSameProvider.Where(x => x.RawMaterialProviderBrandDTO.BrandId == rawMaterialProviderDTO.RawMaterialProviderBrandDTO.BrandId).ToList();

            var validation = rawMaterialWithSameProviderSameBrand.Count() > 0 ? false : true;
            var message = validation ? "Validacion correcta" : "Ya existe un proveedor ligado a esta marca dentro de este producto";

            return new ObjectResponse<bool>(validation, message);
        }
    }
}
