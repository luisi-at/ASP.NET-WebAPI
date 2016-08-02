using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebAPI_Trial.Misc_Classes;
using WebAPI_Trial.Misc_Classes;
using WebAPI_Trial.Interfaces;

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
            builder.RegisterType<DateOutput>().As<IOutput>().InstancePerLifetimeScope();
            //builder.RegisterType<TodayDate>().As<IDateWriter>().InstancePerLifetimeScope();
            builder.RegisterType<EpochDate>().As<IDateWriter>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
