﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

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
               name: "DeleteProduct",
               routeTemplate: "api/deleteproduct/{id}",
               defaults: new { controller = "Products", action = "DeleteProizvodi" }
               );
            config.Routes.MapHttpRoute(
               name: "GetProduct",
               routeTemplate: "api/getproduct/{id}",
               defaults: new { controller = "Products", action = "GetProizvod" }

               );


            config.EnableCors();
        }
    }
}
