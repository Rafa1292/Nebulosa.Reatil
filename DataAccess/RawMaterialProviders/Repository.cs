using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.RawMaterialProviders
{
    public class Repository
    {
        public static ObjectResponse<bool> Insert(RawMaterialProvider rawMaterialProvider)
        {
            using (var db = new DataContext())
            {
                db.RawMaterialProviders.Add(rawMaterialProvider);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Proveedor agregado");
            }

        }

        public static ObjectResponse<bool> Update(RawMaterialProvider rawMaterialProvider)
        {
            using (var db = new DataContext())
            {
                db.Entry(rawMaterialProvider).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Proveedor actualizado");
            }
        }

        public static ObjectResponse<bool> Delete(int rawMaterialProviderId)
        {
            using (var db = new DataContext())
            {
                var rawMaterialProvider = db.RawMaterialProviders.Find(rawMaterialProviderId);
                if (rawMaterialProvider == null)
                    return new ObjectResponse<bool>(false, "No se encontro el proveedor");
                rawMaterialProvider.Delete = true;
                db.Entry(rawMaterialProvider).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Proveedor eliminado");
            }
        }

        public static ObjectResponse<RawMaterialProvider> Get(int rawMaterialProviderId)
        {
            using (var db = new DataContext())
            {
                var rawMaterialProvider = db.RawMaterialProviders.Find(rawMaterialProviderId);
                return new ObjectResponse<RawMaterialProvider>(true, "Consulta exitosa", rawMaterialProvider);
            }
        }

        public static ObjectResponse<List<RawMaterialProvider>> GetAll()
        {
            using (var db = new DataContext())
            {
                var rawMaterialProviders = db.RawMaterialProviders.ToList();
                return new ObjectResponse<List<RawMaterialProvider>>(true, "Consulta exitosa", rawMaterialProviders);
            }
        }
    }
}
