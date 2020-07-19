using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.RawMaterials
{
    public class Repository
    {
        public static ObjectResponse<bool> Insert(RawMaterial rawMaterial)
        {
            using (var db = new DataContext())
            {
                db.rawMaterials.Add(rawMaterial);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Insumo agregado");
            }

        }

        public static ObjectResponse<bool> Update(RawMaterial rawMaterial)
        {
            using (var db = new DataContext())
            {
                db.Entry(rawMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Insumo actualizado");
            }
        }

        public static ObjectResponse<bool> Delete(int rawMaterialId)
        {
            using (var db = new DataContext())
            {
                var rawMaterial = db.rawMaterials.Find(rawMaterialId);
                if (rawMaterial == null)
                    return new ObjectResponse<bool>(false, "No se encontro el insumo");
                rawMaterial.Delete = true;
                db.Entry(rawMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Insumo eliminado");
            }
        }

        public static ObjectResponse<RawMaterial> Get(int rawMaterialId)
        {
            using (var db = new DataContext())
            {
                var rawMaterial = db.rawMaterials.Find(rawMaterialId);
                return new ObjectResponse<RawMaterial>(true, "Consulta exitosa", rawMaterial);
            }
        }

        public static ObjectResponse<List<RawMaterial>> GetAll()
        {
            using (var db = new DataContext())
            {
                var rawMaterials = db.rawMaterials.ToList();
                return new ObjectResponse<List<RawMaterial>>(true, "Consulta exitosa", rawMaterials);
            }
        }
    }
}
