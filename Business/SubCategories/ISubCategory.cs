using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.SubCategories
{
    public interface ISubCategory
    {
        public ObjectResponse<bool> Insert(ProductSubCategory productSubCategory);

        public ObjectResponse<bool> Update(ProductSubCategory productSubCategory);

        public ObjectResponse<bool> Delete(int productSubCategoryId);

        public ObjectResponse<ProductSubCategory> Get(int productSubCategoryId);

        public ObjectResponse<IEnumerable<ProductSubCategory>> GetAll(bool deleteItems);
    }
}
