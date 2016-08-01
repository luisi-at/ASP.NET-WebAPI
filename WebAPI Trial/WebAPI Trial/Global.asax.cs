using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Net.Http.Handlers;
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
            //set the autofac stuff
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();
            builder.RegisterType<MainController>().InstancePerRequest();
            //set the dependency resolver
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
        }
    }
}
