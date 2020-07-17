using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Routes
{
    public class Finisher
    {
        public static Route FinishToInsert(Route route)
        {
            route.DateCreate = DateTime.Now;
            route.DateUpdate = DateTime.Now;
            route.UserCreate = "";//pendiente de implementar
            route.UserUpdate = "";//pendiente de implementar

            return route;
        }

        public static Route FinishToUpdate(Route route)
        {
            route.DateUpdate = DateTime.Now;
            route.UserUpdate = "";//pendiente de implementar

            return route;
        }
    }
}
