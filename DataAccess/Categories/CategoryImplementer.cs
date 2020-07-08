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
            using (var db = new DataContext())
            {
                db.Entry(productCategory).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Categoria actualizada");
            }
        }

        public ObjectResponse<bool> Delete(int productCategoryId)
        {
            using (var db = new DataContext())
            {
                var category = db.ProductCategories.Find(productCategoryId);
                if (category == null)
                    return new ObjectResponse<bool>(false, "No se encontro la categoria");
                category.Delete = true;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Categoria eliminada");
            }
        }

        public ObjectResponse<ProductCategory> Get(int productCategoryId)
        {
            using (var db = new DataContext())
            {
                var category = db.ProductCategories.Find(productCategoryId);
                return new ObjectResponse<ProductCategory>(true, "Consulta exitosa", category);
            }
        }

        public ObjectResponse<IEnumerable<ProductCategory>> GetAll(bool deleteItems)
        {
            using (var db = new DataContext())
            {
                var categories = db.ProductCategories.ToList();
                if (!deleteItems)
                    categories = categories.Where(x => !x.Delete).ToList();
                return new ObjectResponse<IEnumerable<ProductCategory>>(true, "Consulta exitosa", categories);
            }
        }

        #endregion
    }
}
