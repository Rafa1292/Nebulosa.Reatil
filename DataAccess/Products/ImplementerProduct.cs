using Business.Products;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Products
{
    public class ImplementerProduct : IProduct
    {
        #region Metodos
        public ObjectResponse<int> Insert(Product product)
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

        public ObjectResponse<List<Product>> GetAll(bool deleteItems)
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
