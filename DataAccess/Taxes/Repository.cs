using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Taxes
{
    public class Repository
    {
        #region Metodos
        public static ObjectResponse<bool> Insert(Tax tax)
        {
            using (var db = new DataContext())
            {
                db.Taxes.Add(tax);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Impuesto agregado");
            }

        }

        public static ObjectResponse<bool> Update(Tax tax)
        {
            using (var db = new DataContext())
            {
                db.Entry(tax).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Impuesto actualizado");
            }
        }

        public static ObjectResponse<bool> Delete(int taxId)
        {
            using (var db = new DataContext())
            {
                var tax = db.Taxes.Find(taxId);
                if (tax == null)
                    return new ObjectResponse<bool>(false, "No se encontro el impuesto");

                tax.Delete = true;
                db.Entry(tax).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Impuesto eliminado");
            }
        }

        public static ObjectResponse<Tax> Get(int taxId)
        {
            using (var db = new DataContext())
            {
                var tax = db.Taxes.Find(taxId);
                return new ObjectResponse<Tax>(true, "Consulta exitosa", tax);
            }
        }

        public static ObjectResponse<List<Tax>> GetAll()
        {
            using (var db = new DataContext())
            {
                var taxes = db.Taxes.ToList();
                return new ObjectResponse<List<Tax>>(true, "Consulta exitosa", taxes);
            }
        }

        #endregion
    }
}
