using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.ProductTaxes
{
    public class Repository
    {
        #region Metodos
        public static ObjectResponse<bool> Insert(ProductTax productTax)
        {
            using (var db = new DataContext())
            {
                db.ProductTaxes.Add(productTax);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Impuesto relacionado");
            }

        }

        public static ObjectResponse<bool> Update(ProductTax productTax)
        {
            using (var db = new DataContext())
            {
                db.Entry(productTax).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Relacion actualizada");
            }
        }

        public static ObjectResponse<bool> Delete(int productTaxId)
        {
            using (var db = new DataContext())
            {
                var productTax = db.ProductTaxes.Find(productTaxId);
                if (productTax == null)
                    return new ObjectResponse<bool>(false, "No se encontro el impuesto relacionado");
                productTax.Delete = true;
                db.Entry(productTax).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Relacion eliminada");
            }
        }

        public static ObjectResponse<ProductTax> Get(int productTaxId)
        {
            using (var db = new DataContext())
            {
                var productTax = db.ProductTaxes.Find(productTaxId);
                return new ObjectResponse<ProductTax>(true, "Consulta exitosa", productTax);
            }
        }

        public static ObjectResponse<IEnumerable<ProductTax>> GetAll()
        {
            using (var db = new DataContext())
            {
                var productTaxes = db.ProductTaxes.ToList();
                return new ObjectResponse<IEnumerable<ProductTax>>(true, "Consulta exitosa", productTaxes);
            }
        }

        #endregion
    }
}
