using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Products
{
    public class Repository
    {
        #region Metodos
        public static ObjectResponse<bool> Insert(Product product)
        {
            using (var db = new DataContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Producto agregado");
            }

        }

        public static ObjectResponse<bool> Update(Product product)
        {
            using (var db = new DataContext())
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Producto actualizado");
            }
        }

        public static ObjectResponse<bool> Delete(int productId)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.Find(productId);
                if (product == null)
                    return new ObjectResponse<bool>(false, "No se encontro el producto");
                product.Delete = true;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Producto eliminado");
            }
        }

        public static ObjectResponse<Product> Get(int productId)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.Find(productId);
                return new ObjectResponse<ProductCategory>(true, "Consulta exitosa", product);
            }
        }

        public static ObjectResponse<IEnumerable<Product>> GetAll()
        {
            using (var db = new DataContext())
            {
                var products = db.Products.ToList();
                return new ObjectResponse<IEnumerable<Product>>(true, "Consulta exitosa", products);
            }
        }

        #endregion
    }
}
