using Business.SubCategories;
using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.SubCategories
{
    public class SubCategoryImplementer : ISubCategory
    {
        #region Metodos
        public ObjectResponse<bool> Insert(ProductSubCategory productSubCategory)
        {
            return Repository.Insert(productSubCategory);
        }

        public ObjectResponse<bool> Update(ProductSubCategory productSubCategory)
        {
            return Repository.Update(productSubCategory);
        }

        public ObjectResponse<bool> Delete(int productSubCategoryId)
        {
            return Repository.Delete(productSubCategoryId);
        }

        public ObjectResponse<ProductSubCategory> Get(int productSubCategoryId)
        {
            return Repository.Get(productSubCategoryId);
        }

        public ObjectResponse<IEnumerable<ProductSubCategory>> GetAll(bool deleteItems)
        {
            var subCategories = Repository.GetAll();

            if (!subCategories.IsSuccess)
                return subCategories;

            if (!deleteItems)
                subCategories.Data = subCategories.Data.ToList().Where(x => !x.Delete).ToList();
            return subCategories;
        }

        #endregion
    }
}
