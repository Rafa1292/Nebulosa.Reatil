using Business.ModelsDTO;
using Business.RawMaterialProviders;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Business.Measures
{
    public class RouterMeasure
    {
        private readonly IMeasure _measure;
        private readonly RouterRawMaterialProvider _routerMaterialProvider;

        public RouterMeasure(IMeasure measure, RouterRawMaterialProvider routerRawMaterialProvider)
        {
            _measure = measure;
            _routerMaterialProvider = routerRawMaterialProvider;
        }

        public ObjectResponse<bool> Insert(MeasureDTO measureDTO)
        {
            using (var scope = new TransactionScope())
            {
                var measure = MapperMeasure.MapFromDTO(measureDTO, new Measure());
                measure = Finisher.FinishToInsert(measure);

                var measures = _measure.GetAll(false);
                if (!measures.IsSuccess)
                    return new ObjectResponse<bool>(false, measures.Message);

                var validation = ValidateMeasure.ValidateToInsert(measure, measures.Data);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _measure.Insert(measure);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(MeasureDTO measureDTO)
        {
            using (var scope = new TransactionScope())
            {
                var currentMeasure = _measure.Get(measureDTO.MeasureID);
                if (!currentMeasure.IsSuccess)
                    return new ObjectResponse<bool>(false, currentMeasure.Message);

                var measure = MapperMeasure.MapFromDTO(measureDTO, currentMeasure.Data);
                measure = Finisher.FinishToUpdate(measure);
                var validation = ValidateMeasure.ValidateToInsert(measure, _measure.GetAll(false).Data);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _measure.Update(measure);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int measureId)
        {
            using (var scope = new TransactionScope())
            {
                var rawMaterialProviders = _routerMaterialProvider.GetAll(false);
                if (!rawMaterialProviders.IsSuccess)
                    return new ObjectResponse<bool>(false, rawMaterialProviders.Message);

                var relationship = ValidateMeasure.ValidateToDelete(measureId, rawMaterialProviders.Data);
                if (!relationship.IsSuccess)
                    return relationship;

                var actionResponse = _measure.Delete(measureId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<MeasureDTO> Get(int measureId)
        {
            var actionResponse = _measure.Get(measureId);

            if (!actionResponse.IsSuccess)
                return new ObjectResponse<MeasureDTO>(false, actionResponse.Message);

            var measureDTO = MapperMeasure.MapToDTO(actionResponse.Data);

            return new ObjectResponse<MeasureDTO>(true, actionResponse.Message, measureDTO);
        }

        public ObjectResponse<List<MeasureDTO>> GetAll(bool deleteItems)
        {
            var actionResponse = _measure.GetAll(deleteItems);
            if (!actionResponse.IsSuccess)
                return new ObjectResponse<List<MeasureDTO>>(false, actionResponse.Message);

            var productCategoriesDTO = MapperMeasure.MapToDTO(actionResponse.Data);

            return new ObjectResponse<List<MeasureDTO>>(true, actionResponse.Message, productCategoriesDTO);
        }
    }
}
