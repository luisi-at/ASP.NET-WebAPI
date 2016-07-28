using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Diagnostics.Tracing;



namespace WebAPI_Trial
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new MessageHandler1());
            //Central Exception Handler Config
            config.Services.Replace(typeof(IExceptionHandler), new CentralExceptionHandler());
            //Central Logging and Trace Config
            config.Services.Replace(typeof(IExceptionLogger), new TraceExceptions());
            

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
