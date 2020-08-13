using Business.ModelsDTO;
using Business.PreparationItems;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Preparations
{
    public class RouterPreparation
    {
        private readonly IPreparation _preparation;
        private readonly RouterPreparationItem _preparationItem;

        public RouterPreparation(IPreparation preparation, RouterPreparationItem preparationItem)
        {
            _preparation = preparation;
            _preparationItem = preparationItem;
        }

        public ObjectResponse<List<PreparationDTO>> GetAll(bool deleteItems)
        {
            var preparationsResponse = _preparation.GetAll(deleteItems);
            if (!preparationsResponse.IsSuccess)
                return new ObjectResponse<List<PreparationDTO>>(false, preparationsResponse.Message);

            var preparationItemsResponse = _preparationItem.GetAll(deleteItems);
            if (!preparationItemsResponse.IsSuccess)
                return new ObjectResponse<List<PreparationDTO>>(false, preparationItemsResponse.Message);

            var preparationsDTO = MapperPreparation.MapToDTO(preparationsResponse.Data);

            preparationsDTO = Finisher.FinishToGetAll(preparationsDTO, preparationItemsResponse.Data);

            return new ObjectResponse<List<PreparationDTO>>(true, "Consulta exitosa", preparationsDTO);
        }

    }
}
