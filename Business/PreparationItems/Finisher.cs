using Business.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.PreparationItems
{
    public class Finisher
    {
        public static List<PreparationItemDTO> FinishToGetAll(List<PreparationItemDTO> preparationItems, List<MeasureDTO> measures, List<RawMaterialDTO> rawMaterials)
        {
            preparationItems.ForEach(x => x.MeasureDTO = measures.Find(y => y.MeasureId == x.MeasureId));
            preparationItems.ForEach(x => x.RawMaterialDTO = rawMaterials.Find(y => y.RawMaterialId == x.RawMaterialId));

            return preparationItems;
        }
    }
}
