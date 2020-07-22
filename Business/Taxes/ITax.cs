using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Taxes
{
    public interface ITax
    {
        public ObjectResponse<bool> Insert(Tax tax);

        public ObjectResponse<bool> Update(Tax tax);

        public ObjectResponse<bool> Delete(int taxId);

        public ObjectResponse<Tax> Get(int taxId);

        public ObjectResponse<List<Tax>> GetAll(bool deleteItems);
    }
}
