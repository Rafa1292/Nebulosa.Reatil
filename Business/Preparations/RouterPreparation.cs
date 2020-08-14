using Business.ModelsDTO;
using Business.PreparationItems++;
using Common;
using Common.Models;
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

        public ObjectResponse<bool> Insert(PreparationDTO preparationDTO)
        {
            var preparation = PrepareToDataBase(preparationDTO, new Preparation());
            if (!preparation.IsSuccess)
                return new ObjectResponse<bool>(false, preparation.Message);

            var actionResponse = _preparation.Insert(preparation.Data);
            if (!actionResponse.IsSuccess)
                return new ObjectResponse<bool>(false, actionResponse.Message);

            var relationsResponse = InsertRelationship(actionResponse.Data, preparationDTO.PreparationItemsDTO);
            if (!relationsResponse.IsSuccess)
                return relationsResponse;

            return new ObjectResponse<bool>(true, "Preparacion agregada");
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

        public ObjectResponse<Preparation> PrepareToDataBase(PreparationDTO preparationDTO, Preparation currentPreparation)
        {
            var preparation = MapperPreparation.MapFromDTO(preparationDTO, currentPreparation);
            preparation = Finisher.FinishToDatabase(preparation);

            var currentPreparations = _preparation.GetAll(false);
            if (!currentPreparations.IsSuccess)
                return new ObjectResponse<Preparation>(false, currentPreparations.Message);

            var validate = ValidatePreparation.ValidateToInsert(preparation, currentPreparations.Data);
            if (!validate.IsSuccess)
                return new ObjectResponse<Preparation>(false, validate.Message);

            return new ObjectResponse<Preparation>(true, "Listo para Base de datos", preparation);
        }

        public ObjectResponse<bool> InsertRelationship(int preparationId, List<PreparationItemDTO> preparationItemsDTO)
        {
            foreach (var preparationItem in preparationItemsDTO)
            {
                preparationItem.PreparationId = preparationId;
               var actionResponse = _preparationItem.Insert(preparationItem);
                if (!actionResponse.IsSuccess)
                    return actionResponse;
            }

            return new ObjectResponse<bool>(true, "Relaciones insertadas correctamente");
        }
    }
}
