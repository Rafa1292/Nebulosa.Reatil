using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Providers
{
    public class Repository
    {
        #region Metodos
        public static ObjectResponse<bool> Insert(Provider provider)
        {
            using (var db = new DataContext())
            {
                db.Providers.Add(provider);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Proveedor agregado");
            }

        }

        public static ObjectResponse<bool> Update(Provider provider)
        {
            using (var db = new DataContext())
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Proveedor actualizado");
            }
        }

        public static ObjectResponse<bool> Delete(int providerId)
        {
            using (var db = new DataContext())
            {
                var provider = db.ProductCategories.Find(providerId);
                if (provider == null)
                    return new ObjectResponse<bool>(false, "No se encontro el proveedor");
                provider.Delete = true;
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Proveedor eliminado");
            }
        }

        public static ObjectResponse<Provider> Get(int providerId)
        {
            using (var db = new DataContext())
            {
                var provider = db.Providers.Find(providerId);
                return new ObjectResponse<Provider>(true, "Consulta exitosa", provider);
            }
        }

        public static ObjectResponse<IEnumerable<Provider>> GetAll()
        {
            using (var db = new DataContext())
            {
                var providers = db.Providers.ToList();
                return new ObjectResponse<IEnumerable<Provider>>(true, "Consulta exitosa", providers);
            }
        }

        #endregion
    }
}
