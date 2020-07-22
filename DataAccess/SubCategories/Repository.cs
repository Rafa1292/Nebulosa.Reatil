using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.SubCategories
{
    public class Repository
    {
        #region Metodos
        public static ObjectResponse<bool> Insert(ProductSubCategory productSubCategory)
        {
            using (var db = new DataContext())
            {
                db.ProductSubCategories.Add(productSubCategory);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "SubCategoria agregada");
            }

        }

        public static ObjectResponse<bool> Update(ProductSubCategory productSubCategory)
        {
            using (var db = new DataContext())
            {
                db.Entry(productSubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "SubCategoria actualizada");
            }
        }

        public static ObjectResponse<bool> Delete(int productSubCategoryId)
        {
            using (var db = new DataContext())
            {
                var category = db.ProductSubCategories.Find(productSubCategoryId);
                if (category == null)
                    return new ObjectResponse<bool>(false, "No se encontro la subCategoria");
                category.Delete = true;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "SubCategoria eliminada");
            }
        }

        public static ObjectResponse<ProductSubCategory> Get(int productSubCategoryId)
        {
            using (var db = new DataContext())
            {
                var subCategory = db.ProductSubCategories.Find(productSubCategoryId);
                return new ObjectResponse<ProductSubCategory>(true, "Consulta exitosa", subCategory);
            }
        }

        public static ObjectResponse<List<ProductSubCategory>> GetAll()
        {
            using (var db = new DataContext())
            {
                var subCategories = db.ProductSubCategories.ToList();
                return new ObjectResponse<List<ProductSubCategory>>(true, "Consulta exitosa", subCategories);
            }
        }

        #endregion
    }
}
