using Business.Measures;
using Business.ModelsDTO;
using Business.RawMaterials;
using Common;
using Common.Models;
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

        public ObjectResponse<bool> Insert(PreparationItemDTO preparationItemDTO)
        {
            var validation = PrepareToDataBase(preparationItemDTO, new PreparationItem());
            if (!validation.IsSuccess)
                return new ObjectResponse<bool>(false, validation.Message);

            var preparationItem = validation.Data;

            var actionResponse = _preparationItem.Insert(preparationItem);

            return actionResponse;

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

        public ObjectResponse<PreparationItem> PrepareToDataBase(PreparationItemDTO preparationItemDTO, PreparationItem currentPreparationItem)
        {
            var preparationItem = MapperPreparationItem.MapFromDTO(preparationItemDTO, currentPreparationItem);
            preparationItem = Finisher.FinishToDatabase(preparationItem);

            var currentPreparationItems = _preparationItem.GetAll(false);
            if (!currentPreparationItems.IsSuccess)
                return new ObjectResponse<PreparationItem>(false, currentPreparationItems.Message);

            var validate = ValidatePreparationItem.ValidateToInsert(preparationItem, currentPreparationItems.Data);
            if(!validate.IsSuccess)
                return new ObjectResponse<PreparationItem>(false, validate.Message);

            return new ObjectResponse<PreparationItem>(true, "Listo para Base de datos", preparationItem);
        }


    }
}
