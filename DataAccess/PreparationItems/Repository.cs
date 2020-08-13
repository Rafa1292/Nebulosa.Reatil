using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Common.Models;


namespace DataAccess.PreparationItems
{
    public class Repository
    {
        public static ObjectResponse<bool> Insert(PreparationItem preparationItem)
        {
            using (var db = new DataContext())
            {
                db.PreparationItems.Add(preparationItem);
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Item agregado");
            }
        }

        public static ObjectResponse<List<PreparationItem>> GetAll()
        {
            using (var db = new DataContext())
            {
                var preparationItems = db.PreparationItems.ToList();
                return new ObjectResponse<List<PreparationItem>>(true, "Consulta exitosa", preparationItems);
            }
        }
    }
}
