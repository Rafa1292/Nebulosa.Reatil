using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Measures
{
    public interface IMeasure
    {
        public ObjectResponse<bool> Insert(Measure measure);

        public ObjectResponse<bool> Update(Measure measure);

        public ObjectResponse<bool> Delete(int measureId);

        public ObjectResponse<Measure> Get(int measureId);

        public ObjectResponse<List<Measure>> GetAll(bool deleteItems);
    }
}
