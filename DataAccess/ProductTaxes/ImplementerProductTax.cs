using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.ProductTaxes
{
    public class ImplementerProductTax
    {
        #region Metodos
        public ObjectResponse<bool> Insert(ProductTax productTax)
        {
            return Repository.Insert(productTax);
        }

        public ObjectResponse<bool> Update(ProductTax productTax)
        {
            return Repository.Update(productTax);
        }

        public ObjectResponse<bool> Delete(int productTaxId)
        {
            return Repository.Delete(productTaxId);
        }

        public ObjectResponse<ProductTax> Get(int productTaxId)
        {
            return Repository.Get(productTaxId);
        }

        public ObjectResponse<IEnumerable<ProductTax>> GetAll(bool deleteItems)
        {
            var productTaxes = Repository.GetAll();

            if (!productTaxes.IsSuccess)
                return productTaxes;

            if (!deleteItems)
                productTaxes.Data = productTaxes.Data.ToList().Where(x => !x.Delete).ToList();

            return productTaxes;
        }

        #endregion
    }
}
