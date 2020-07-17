using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Products
{
    public interface IProduct
    {
        public ObjectResponse<int> Insert(Product product);

        public ObjectResponse<bool> Update(Product product);

        public ObjectResponse<bool> Delete(int productId);

        public ObjectResponse<Product> Get(int productId);

        public ObjectResponse<List<Product>> GetAll(bool deleteItems);
    }
}
