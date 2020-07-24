using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Measures
{
    public class ValidateMeasure
    {
        public static ObjectResponse<bool> ValidateToInsert(Measure measure, List<Measure> measures)
        {
            bool validateNullName =  String.IsNullOrWhiteSpace(measure.Name);

            if (validateNullName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool NameExist = measures
                .Where(x => x.MeasureId != measure.MeasureId)
                .Select(x => x.Name.ToLower())
                .Contains(measure.Name.ToLower());

            if (NameExist)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");



            return new ObjectResponse<bool>(true, "Medida validada");
        }

        public static ObjectResponse<bool> ValidateToDelete(int measureId, List<RawMaterialProvider> rawMaterialProviders)
        {
            var Relationship = rawMaterialProviders.Select(x => x.MeasureId).Contains(measureId);
            if (Relationship)
                return new ObjectResponse<bool>(false, "Debes eliminar los productos asociados antes de seguir con esta accion");


            return new ObjectResponse<bool>(true, "Medida validada");
        }
    }
}
