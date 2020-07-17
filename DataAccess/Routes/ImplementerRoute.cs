using Business.Routes;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Routes
{
    public class ImplementerRoute : IRoute
    {
        #region Metodos
        public ObjectResponse<bool> Insert(Route route)
        {
            return Repository.Insert(route);
        }

        public ObjectResponse<bool> Update(Route route)
        {
            return Repository.Update(route);
        }

        public ObjectResponse<bool> Delete(int routeId)
        {
            return Repository.Delete(routeId);
        }

        public ObjectResponse<Route> Get(int routeId)
        {
            return Repository.Get(routeId);
        }

        public ObjectResponse<IEnumerable<Route>> GetAll(bool deleteItems)
        {
            var routes = Repository.GetAll();

            if (!routes.IsSuccess)
                return routes;

            if (!deleteItems)
                routes.Data = routes.Data.ToList().Where(x => !x.Delete).ToList();

            return routes;
        }

        #endregion
    }
}
