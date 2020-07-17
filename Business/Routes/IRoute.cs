using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Routes
{
    public interface IRoute
    {
        public ObjectResponse<bool> Insert(Route route);

        public ObjectResponse<bool> Update(Route route);

        public ObjectResponse<bool> Delete(int routeId);

        public ObjectResponse<Route> Get(int routeId);

        public ObjectResponse<IEnumerable<Route>> GetAll(bool deleteItems);
    }
}
