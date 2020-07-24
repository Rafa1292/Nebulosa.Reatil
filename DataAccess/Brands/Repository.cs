using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Brands
{
    public class Repository
    {
        public static ObjectResponse<bool> Insert(Brand brand)
        {
            using (var db = new DataContext())
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Marca agregada");
            }

        }

        public static ObjectResponse<bool> Update(Brand brand)
        {
            using (var db = new DataContext())
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Marca actualizada");
            }
        }

        public static ObjectResponse<bool> Delete(int brandId)
        {
            using (var db = new DataContext())
            {
                var brand = db.Brands.Find(brandId);
                if (brand == null)
                    return new ObjectResponse<bool>(false, "No se encontro la marca");

                brand.Delete = true;
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Marca eliminada");
            }
        }

        public static ObjectResponse<Brand> Get(int brandId)
        {
            using (var db = new DataContext())
            {
                var brand = db.Brands.Find(brandId);
                return new ObjectResponse<Brand>(true, "Consulta exitosa", brand);
            }
        }

        public static ObjectResponse<List<Brand>> GetAll()
        {
            using (var db = new DataContext())
            {
                var brands = db.Brands.ToList();
                return new ObjectResponse<List<Brand>>(true, "Consulta exitosa", brands);
            }
        }
    }
}
