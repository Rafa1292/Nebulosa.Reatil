using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;

namespace Business.Categories
{
    public interface ICategory
    {
        public ObjectResponse<bool> Insert(ProductCategory productCategory);

        public ObjectResponse<bool> Update(ProductCategory productCategory);

        public ObjectResponse<bool> Delete(int productCategoryId);

        public ObjectResponse<ProductCategory> Get(int productCategoryId);

        public ObjectResponse<List<ProductCategory>> GetAll(bool deleteItems);

    }
}
