using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Products
{
    public class ImplementerProduct
    {
        #region Metodos
        public ObjectResponse<bool> Insert(Product product)
        {
            return Repository.Insert(product);
        }

        public ObjectResponse<bool> Update(Product product)
        {
            return Repository.Update(product);
        }

        public ObjectResponse<bool> Delete(int productId)
        {
            return Repository.Delete(productId);
        }

        public ObjectResponse<Product> Get(int productId)
        {
            return Repository.Get(productId);
        }

        public ObjectResponse<IEnumerable<Product>> GetAll(bool deleteItems)
        {
            var products = Repository.GetAll();

            if (!products.IsSuccess)
                return products;

            if (!deleteItems)
                products.Data = products.Data.ToList().Where(x => !x.Delete).ToList();

            return products;
        }

        #endregion
    }
}
