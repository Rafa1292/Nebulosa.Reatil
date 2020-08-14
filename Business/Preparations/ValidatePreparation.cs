using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Preparations
{
    public class ValidatePreparation
    {
        public static ObjectResponse<bool> ValidateToInsert(Preparation preparation, List<Preparation> preparations)
        {
            bool validatepreparation = String.IsNullOrWhiteSpace(preparation.Name);

            if (validatepreparation)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool validateWeight = preparation.Weight > 0 ? true : false;

            if (!validateWeight)
                return new ObjectResponse<bool>(false, "Debe asignar un peso");

            var validateName = ValidateDontRepeatName(preparation, preparations);
            if (!validateName)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");

            return new ObjectResponse<bool>(true, "Listo para base de datos");
        }

        public static bool ValidateDontRepeatName(Preparation preparation, List<Preparation> preparations)
        {
            var validate = preparations.Where(x => x.Name == preparation.Name);

            if (validate.Count() > 0)
                return false;

            return true;
        }
    }
}
