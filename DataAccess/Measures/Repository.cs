using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Measures
{
    public class Repository
    {
        public static ObjectResponse<bool> Insert(Measure measure)
        {
            using (var db = new DataContext())
            {
                db.Measures.Add(measure);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Medida agregada");
            }

        }

        public static ObjectResponse<bool> Update(Measure measure)
        {
            using (var db = new DataContext())
            {
                db.Entry(measure).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Medida actualizada");
            }
        }

        public static ObjectResponse<bool> Delete(int measureId)
        {
            using (var db = new DataContext())
            {
                var measure = db.Measures.Find(measureId);
                if (measure == null)
                    return new ObjectResponse<bool>(false, "No se encontro la medida");
                measure.Delete = true;
                db.Entry(measure).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Medida eliminada");
            }
        }

        public static ObjectResponse<Measure> Get(int measureId)
        {
            using (var db = new DataContext())
            {
                var measure = db.Measures.Find(measureId);
                return new ObjectResponse<Measure>(true, "Consulta exitosa", measure);
            }
        }

        public static ObjectResponse<List<Measure>> GetAll()
        {
            using (var db = new DataContext())
            {
                var measures = db.Measures.ToList();
                return new ObjectResponse<List<Measure>>(true, "Consulta exitosa", measures);
            }
        }

    }
}
