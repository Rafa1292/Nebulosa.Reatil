using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Categories
{
    public class Repository
    {

        #region Metodos
        public static ObjectResponse<bool> Insert(ProductCategory productCategory)
        {
            using (var db = new DataContext())
            {
                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Categoria agregada");
            }

        }

        public static ObjectResponse<bool> Update(ProductCategory productCategory)
        {
            using (var db = new DataContext())
            {
                db.Entry(productCategory).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Categoria actualizada");
            }
        }

        public static ObjectResponse<bool> Delete(int productCategoryId)
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

        public static ObjectResponse<ProductCategory> Get(int productCategoryId)
        {
            using (var db = new DataContext())
            {
                var category = db.ProductCategories.Find(productCategoryId);
                return new ObjectResponse<ProductCategory>(true, "Consulta exitosa", category);
            }
        }

        public static ObjectResponse<IEnumerable<ProductCategory>> GetAll()
        {
            using (var db = new DataContext())
            {
                var categories = db.ProductCategories.ToList();
                return new ObjectResponse<IEnumerable<ProductCategory>>(true, "Consulta exitosa", categories);
            }
        }

        #endregion
    }
}
