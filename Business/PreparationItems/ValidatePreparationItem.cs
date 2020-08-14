using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.PreparationItems
{
    public class ValidatePreparationItem
    {
        public static ObjectResponse<bool> ValidateToInsert(PreparationItem preparationItem, List<PreparationItem> preparationItems)
        {
            bool validateQuantity = preparationItem.Quantiy > 0 ? true : false;

            if (!validateQuantity)
                return new ObjectResponse<bool>(false, "La cantidad debe ser mayor a 0");

            bool validateRawMaterial = preparationItem.RawMaterialId > 0 ? true : false;

            if (!validateRawMaterial)
                return new ObjectResponse<bool>(false, "Debe seleccionar un insumo");

            bool validateMeasure = preparationItem.MeasureId > 0 ? true : false;

            if (!validateMeasure)
                return new ObjectResponse<bool>(false, "Debe seleccionar una medida");

            bool validatePreparation = preparationItem.PreparationId > 0 ? true : false;

            if (!validatePreparation)
                return new ObjectResponse<bool>(false, "Debe asignar una preparacion");

            bool validateWeight = preparationItem.Weight > 0 ? true : false;

            if (!validateWeight)
                return new ObjectResponse<bool>(false, "Debe asignar un peso");

            if (!ValidateDontRepeatItem(preparationItem, preparationItems))
                return new ObjectResponse<bool>(false, "Ya existe este insumo en esta preparacion");

            return new ObjectResponse<bool>(true, "Item validado");
        }

       public static  bool ValidateDontRepeatItem(PreparationItem preparationItem, List<PreparationItem> preparationItems)
        {
            var currentPreparationItems = preparationItems.Where(x => x.PreparationId == preparationItem.PreparationId).Select(y => y.RawMaterialId);

            var validate = currentPreparationItems.Contains(preparationItem.RawMaterialId);

            return !validate;
        }
    }
}
