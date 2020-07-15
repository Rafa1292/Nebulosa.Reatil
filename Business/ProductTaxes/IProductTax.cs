using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProductTaxes
{
    public interface IProductTax
    {
        public ObjectResponse<bool> Insert(List<ProductTax> productTaxes, int productId);

        public ObjectResponse<bool> Update(List<ProductTax> productTaxes, int productId);

        public ObjectResponse<bool> Delete(List<ProductTax> productTaxes);

        public ObjectResponse<List<ProductTax>> Get(int productId, bool deleteItems);

        public ObjectResponse<List<ProductTax>> GetAll(bool deleteItems);
    }
}
