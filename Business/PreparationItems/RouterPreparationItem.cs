using Business.Measures;
using Business.ModelsDTO;
using Business.RawMaterials;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.PreparationItems
{
    public class RouterPreparationItem
    {
        private readonly IPreparationItem _preparationItem;
        private readonly RouterMeasure _measure;
        private readonly RouterRawMaterial _rawMaterial;

        public RouterPreparationItem(IPreparationItem preparationItem, RouterMeasure measure, RouterRawMaterial rawMaterial)
        {
            _preparationItem = preparationItem;
            _measure = measure;
            _rawMaterial = rawMaterial;
        }


        public ObjectResponse<List<PreparationItemDTO>> GetAll(bool deleteItems)
        {
            var preparationItemsResponse = _preparationItem.GetAll(deleteItems);

            if (!preparationItemsResponse.IsSuccess)
                return new ObjectResponse<List<PreparationItemDTO>>(false, preparationItemsResponse.Message);

            var measures = _measure.GetAll(false);
            if (!measures.IsSuccess)
                return new ObjectResponse<List<PreparationItemDTO>>(false, measures.Message);

            var rawMaterials = _rawMaterial.GetAll(false);
            if (!rawMaterials.IsSuccess)
                return new ObjectResponse<List<PreparationItemDTO>>(false, rawMaterials.Message);

            var preparationItemsDTO = MapperPreparationItem.MapToDTO(preparationItemsResponse.Data);
            preparationItemsDTO = Finisher.FinishToGetAll(preparationItemsDTO, measures.Data, rawMaterials.Data);

            return new ObjectResponse<List<PreparationItemDTO>>(true,"Consulta exitosa", preparationItemsDTO);
        }

    }
}
