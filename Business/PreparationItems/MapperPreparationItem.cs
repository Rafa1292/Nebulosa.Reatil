using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.PreparationItems
{
    public class MapperPreparationItem
    {

        public static List<PreparationItemDTO> MapToDTO(List<PreparationItem> preparationItems)
        {
            var preparationItemsDTO = new List<PreparationItemDTO>();

            preparationItems.ForEach(x =>
                preparationItemsDTO.Add(
                    new PreparationItemDTO() { 
                        Cost = x.Cost,
                        MeasureId = x.MeasureId,
                        PreparationId = x.PreparationId,
                        PreparationItemId = x.PreparationItemId,
                        Quantiy = x.Quantiy,
                        RawMaterialId = x.RawMaterialId,
                        Weight = x.Weight
                    }));

            return preparationItemsDTO;
        }
    }
}
