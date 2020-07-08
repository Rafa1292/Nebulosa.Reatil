using Business.Categories;
using Business.ModelsDTO;
using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Categories
{
    public class CategoryImplementer : ICategory
    {
        #region Metodos
        public ObjectResponse<bool> Insert(ProductCategory productCategory)
        {
            return Repository.Insert(productCategory);
        }

        public ObjectResponse<bool> Update(ProductCategory productCategory)
        {
            return Repository.Update(productCategory);
        }

        public ObjectResponse<bool> Delete(int productCategoryId)
        {
            return Repository.Delete(productCategoryId);
        }

        public ObjectResponse<ProductCategory> Get(int productCategoryId)
        {
            return Repository.Get(productCategoryId);
        }

        public ObjectResponse<IEnumerable<ProductCategory>> GetAll(bool deleteItems)
        {
            using (var db = new DataContext())
            {
                var categories = Repository.GetAll();

                if (!categories.IsSuccess)
                    return categories;

                if (!deleteItems)
                    categories.Data = categories.Data.ToList().Where(x => !x.Delete).ToList();

                return  categories;
            }
        }

        #endregion
    }
}
