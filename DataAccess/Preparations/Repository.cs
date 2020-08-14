using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Preparations
{
    public class Repository
    {
        public static ObjectResponse<int> Insert(Preparation preparation)
        {
            using (var db = new DataContext())
            {
                db.Preparations.Add(preparation);
                db.SaveChanges();
                return new ObjectResponse<int>(true, "Preparacion agregada", preparation.PreparationId);
            }
        }
        public static ObjectResponse<List<Preparation>> GetAll()
        {
            using (var db = new DataContext())
            {
                var preparations = db.Preparations.ToList();
                return new ObjectResponse<List<Preparation>>(true, "Consulta exitosa", preparations);
            }
        }
    }
}
