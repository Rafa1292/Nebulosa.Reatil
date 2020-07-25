using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.RawMaterialProviderBrands
{
    public class Repository
    {
        public static ObjectResponse<bool> Insert(RawMaterialProviderBrand rawMaterialProviderBrand)
        {
            using (var db = new DataContext())
            {
                db.RawMaterialProviderBrands.Add(rawMaterialProviderBrand);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Marca asociada");
            }

        }

        public static ObjectResponse<bool> Update(RawMaterialProviderBrand rawMaterialProviderBrand)
        {
            using (var db = new DataContext())
            {
                db.Entry(rawMaterialProviderBrand).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Relacion actualizado");
            }
        }

        public static ObjectResponse<bool> Delete(int rawMaterialProviderBrandId)
        {
            using (var db = new DataContext())
            {
                var rawMaterialProviderBrand = db.RawMaterialProviderBrands.Find(rawMaterialProviderBrandId);
                if (rawMaterialProviderBrand == null)
                    return new ObjectResponse<bool>(false, "No se encontro la marca relacionada");

                rawMaterialProviderBrand.Delete = true;
                db.Entry(rawMaterialProviderBrand).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Relacion eliminada");
            }
        }

        public static ObjectResponse<RawMaterialProviderBrand> Get(int rawMaterialProviderBrandId)
        {
            using (var db = new DataContext())
            {
                var rawMaterialProviderBrand = db.RawMaterialProviderBrands.Find(rawMaterialProviderBrandId);
                return new ObjectResponse<RawMaterialProviderBrand>(true, "Consulta exitosa", rawMaterialProviderBrand);
            }
        }

        public static ObjectResponse<List<RawMaterialProviderBrand>> GetAll()
        {
            using (var db = new DataContext())
            {
                var rawMaterialProviderBrands = db.RawMaterialProviderBrands.ToList();
                return new ObjectResponse<List<RawMaterialProviderBrand>>(true, "Consulta exitosa", rawMaterialProviderBrands);
            }
        }
    }
}
