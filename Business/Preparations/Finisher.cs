using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Preparations
{
    public class Finisher
    {
        public static Preparation FinishToDatabase(Preparation preparation)
        {
            if (!(preparation.DateCreate > new DateTime(1 / 1 / 1)))
            {
                preparation.DateCreate = DateTime.Now;
                preparation.UserCreate = "";//pendiente de implementar
            }
            preparation.DateUpdate = DateTime.Now;
            preparation.UserUpdate = "";//pendiente de implementar

            return preparation;
        }

        public static List<PreparationDTO> FinishToGetAll(List<PreparationDTO> preparations, List<PreparationItemDTO> preparationItems)
        {
            preparations.ForEach(x => x.PreparationItemsDTO = preparationItems.Where(y => y.PreparationId == x.PreparationId).ToList());

            return preparations;
        }
    }
}
