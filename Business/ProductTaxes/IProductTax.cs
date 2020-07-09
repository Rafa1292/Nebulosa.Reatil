using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProductTaxes
{
    public interface IProductTax
    {
        public ObjectResponse<bool> Insert(ProductTax productTax);

        public ObjectResponse<bool> Update(ProductTax productTax);

        public ObjectResponse<bool> Delete(int productTaxId);

        public ObjectResponse<ProductTax> Get(int productTaxId);

        public ObjectResponse<IEnumerable<ProductTax>> GetAll(bool deleteItems);
    }
}
