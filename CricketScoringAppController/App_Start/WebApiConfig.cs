using CricketScoringAppController.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CricketScoringAppController
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.MessageHandlers.Add(new CorsHandler());

            // Define and add values to variables: origins, headers, methods (can be global) 
            // Enable global CORS
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Add handler to deal with preflight requests, this is the important part
            //config.MessageHandlers.Add(new PreflightRequestsHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
