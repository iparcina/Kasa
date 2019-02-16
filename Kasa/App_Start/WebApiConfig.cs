using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Kasa
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "GetProducts",
               routeTemplate: "api/products",
               defaults: new { controller = "Products", action = "GetProizvodi" }
               );

            config.Routes.MapHttpRoute(
               name: "SetProducts",
               routeTemplate: "api/addproducts",
               defaults: new { controller = "Products", action = "PostProizvodi" }
               );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
