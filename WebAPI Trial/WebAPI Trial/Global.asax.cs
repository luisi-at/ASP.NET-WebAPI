using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Net.Http.Handlers;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using WebAPI_Trial.Controllers;



namespace WebAPI_Trial
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            //Register custom dependancies for Controller
            builder.RegisterType<DateOutput>().As<IOutput>().SingleInstance();
            builder.RegisterType<MainController.TodayDate>().As<IDateWriter>().SingleInstance();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
