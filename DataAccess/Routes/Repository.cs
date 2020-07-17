using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Routes
{
    public class Repository
    {
        #region Metodos
        public static ObjectResponse<int> Insert(Route route)
        {
            using (var db = new DataContext())
            {
                db.Routes.Add(route);
                db.SaveChanges();
                return new ObjectResponse<int>(true, "Ruta agregada", route.RouteId);
            }

        }

        public static ObjectResponse<bool> Update(Route route)
        {
            using (var db = new DataContext())
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Ruta actualizada");
            }
        }

        public static ObjectResponse<bool> Delete(int routeId)
        {
            using (var db = new DataContext())
            {
                var route = db.Routes.Find(routeId);
                if (route == null)
                    return new ObjectResponse<bool>(false, "No se encontro la ruta");
                route.Delete = true;
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResponse<bool>(true, "Ruta eliminada");
            }
        }

        public static ObjectResponse<Route> Get(int routeId)
        {
            using (var db = new DataContext())
            {
                var route = db.Routes.Find(routeId);
                return new ObjectResponse<Route>(true, "Consulta exitosa", route);
            }
        }

        public static ObjectResponse<IEnumerable<Route>> GetAll()
        {
            using (var db = new DataContext())
            {
                var routes = db.Routes.ToList();
                return new ObjectResponse<IEnumerable<Route>>(true, "Consulta exitosa", routes);
            }
        }

        #endregion
    }
}
