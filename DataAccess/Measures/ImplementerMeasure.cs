using Business.Measures;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Measures
{
    public class ImplementerMeasure : IMeasure
    {
        public ObjectResponse<bool> Insert(Measure measure)
        {
            return Repository.Insert(measure);
        }

        public ObjectResponse<bool> Update(Measure measure)
        {
            return Repository.Update(measure);
        }

        public ObjectResponse<bool> Delete(int measureId)
        {
            return Repository.Delete(measureId);
        }

        public ObjectResponse<Measure> Get(int MeasureId)
        {
            return Repository.Get(MeasureId);
        }

        public ObjectResponse<List<Measure>> GetAll(bool deleteItems)
        {
            var measures = Repository.GetAll();

            if (!measures.IsSuccess)
                return measures;

            if (!deleteItems)
                measures.Data = measures.Data.ToList().Where(x => !x.Delete).ToList();

            return measures;
        }
    }
}
