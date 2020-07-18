using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Routes
{
    public class MapperRoute
    {
        public static Route MapFromDTO(RouteDTO routeDTO, Route route)
        {
            route.RouteId = routeDTO.RouteId;
            route.Lunes = routeDTO.Lunes;
            route.Martes = routeDTO.Martes;
            route.Miercoles = routeDTO.Miercoles;
            route.Jueves = routeDTO.Jueves;
            route.Viernes = routeDTO.Viernes;
            route.Sabado = routeDTO.Sabado;
            route.Domingo = routeDTO.Domingo;

            return route;
        }

        public static RouteDTO MapToDTO(Route route)
        {
            RouteDTO routeDTO = new RouteDTO()
            {
                RouteId = route.RouteId,
                Lunes = route.Lunes,
                Martes = route.Martes,
                Miercoles = route.Miercoles,
                Jueves = route.Jueves,
                Viernes = route.Viernes,
                Sabado = route.Sabado,
                Domingo = route.Domingo
            };

            return routeDTO;
        }

        public static List<RouteDTO> MapToDTO(List<Route> routes)
        {
            List<RouteDTO> routesDTO = new List<RouteDTO>();

            routes.ForEach(x => routesDTO.Add(
                new RouteDTO()
                {
                    RouteId = x.RouteId,
                    Lunes = x.Lunes,
                    Martes = x.Martes,
                    Miercoles = x.Miercoles,
                    Jueves = x.Jueves,
                    Viernes = x.Viernes,
                    Sabado = x.Sabado,
                    Domingo = x.Domingo
                }));

            return routesDTO;
        }
    }
}
