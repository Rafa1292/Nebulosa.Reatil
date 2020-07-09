using Business.Taxes;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Taxes
{
    public class ImplementerTax : ITax
    {
        #region Metodos
        public ObjectResponse<bool> Insert(Tax tax)
        {
            return Repository.Insert(tax);
        }

        public ObjectResponse<bool> Update(Tax tax)
        {
            return Repository.Update(tax);
        }

        public ObjectResponse<bool> Delete(int taxId)
        {
            return Repository.Delete(taxId);
        }

        public ObjectResponse<Tax> Get(int taxId)
        {
            return Repository.Get(taxId);
        }

        public ObjectResponse<IEnumerable<Tax>> GetAll(bool deleteItems)
        {
            var taxes = Repository.GetAll();

            if (!taxes.IsSuccess)
                return taxes;

            if (!deleteItems)
                taxes.Data = taxes.Data.ToList().Where(x => !x.Delete).ToList();

            return taxes;
        }

        #endregion
    }
}
