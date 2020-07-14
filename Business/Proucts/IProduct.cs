using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Proucts
{
    public interface IProduct
    {
        public ObjectResponse<bool> Insert(Product product);

        public ObjectResponse<bool> Update(Product product);

        public ObjectResponse<bool> Delete(int productId);

        public ObjectResponse<Product> Get(int productId);

        public ObjectResponse<IEnumerable<Product>> GetAll(bool deleteItems);
    }
}
