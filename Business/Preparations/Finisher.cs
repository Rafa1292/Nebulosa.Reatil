using Business.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Preparations
{
    public class Finisher
    {
        public static List<PreparationDTO> FinishToGetAll(List<PreparationDTO> preparations, List<PreparationItemDTO> preparationItems)
        {
            preparations.ForEach(x => x.PreparationItemsDTO = preparationItems.Where(y => y.PreparationId == x.PreparationId).ToList());

            return preparations;
        }
    }
}
