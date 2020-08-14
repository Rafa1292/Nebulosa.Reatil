using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.PreparationItems
{
    public class Finisher
    {
        public static PreparationItem FinishToDatabase(PreparationItem preparationItem)
        {
            if (!(preparationItem.DateCreate > new DateTime(1 / 1 / 1)))
            {
                preparationItem.DateCreate = DateTime.Now;
                preparationItem.UserCreate = "";//pendiente de implementar
            }
            preparationItem.DateUpdate = DateTime.Now;
            preparationItem.UserUpdate = "";//pendiente de implementar

            return preparationItem;
        }
        public static List<PreparationItemDTO> FinishToGetAll(List<PreparationItemDTO> preparationItems, List<MeasureDTO> measures, List<RawMaterialDTO> rawMaterials)
        {
            preparationItems.ForEach(x => x.MeasureDTO = measures.Find(y => y.MeasureId == x.MeasureId));
            preparationItems.ForEach(x => x.RawMaterialDTO = rawMaterials.Find(y => y.RawMaterialId == x.RawMaterialId));

            return preparationItems;
        }
    }
}
