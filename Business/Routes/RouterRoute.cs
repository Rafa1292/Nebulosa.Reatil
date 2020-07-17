using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Routes
{
    public class RouterRoute
    {
        private readonly IRoute _route;

        public RouterRoute(IRoute route)
        {
            _route = route;
        }

        public ObjectResponse<int> Insert(RouteDTO routeDTO)
        {
            using (var scope = new TransactionScope())
            {
                var route = MapperRoute.MapFromDTO(routeDTO, new Route());
                route = Finisher.FinishToInsert(route);
                var validation = ValidateRoute.ValidateToInsert(route);

                if (!validation.IsSuccess)
                    return new ObjectResponse<int>(false,validation.Message);

                var actionResponse = _route.Insert(route);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(RouteDTO routeDTO)
        {
            using (var scope = new TransactionScope())
            {

                var route = MapperRoute.MapFromDTO(routeDTO , new Route());
                route = Finisher.FinishToUpdate(route);
                var validation = ValidateRoute.ValidateToInsert(route);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _route.Update(route);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int routeId)
        {
            using (var scope = new TransactionScope())
            {
                var actionResponse = _route.Delete(routeId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<RouteDTO> Get(int routeId)
        {
            var routeResponse = _route.Get(routeId);

            if (!routeResponse.IsSuccess)
                return new ObjectResponse<RouteDTO>(false, routeResponse.Message);

            var routeDTO = MapperRoute.MapToDTO(routeResponse.Data);

            return new ObjectResponse<RouteDTO>(true, routeResponse.Message, routeDTO);
        }

        public ObjectResponse<List<RouteDTO>> GetAll(bool deleteItems)
        {
            var routesResponse = _route.GetAll(deleteItems);
            if (!routesResponse.IsSuccess)
                return new ObjectResponse<List<RouteDTO>>(false, routesResponse.Message);


            var routesDTO = MapperRoute.MapToDTO(routesResponse.Data.ToList());

            return new ObjectResponse<List<RouteDTO>>(true, routesResponse.Message, routesDTO);
        }
    }
}
