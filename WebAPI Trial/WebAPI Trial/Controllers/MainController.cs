using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Runtime.Remoting.Messaging;
using Autofac;

//demonstration of WebAPI with Autofac

namespace WebAPI_Trial.Controllers
{
    public class MainController : ApiController
    {
        private static IContainer Container { get; set; }
        // GET: api/Main
        public Something Get()
        {
            //throw new ArgumentNullException("Something");
            
            return new Something { type = "SomeType", model = "SomeModel", color = "Colour" };
        }

        // GET: api/Main/5
        public string Get(int id) 
        {
            
            //CallContext.LogicalSetData("MyData", "Some Data");
            
            //var myData = CallContext.LogicalGetData("DATA");
            var myData = "";
            //use autofac to return todays date here to the http response
            var builder = new ContainerBuilder();
            builder.RegisterType<TodayDate>().As<IDateWriter>();
            Container = builder.Build();

            //Need to figure out how to return the value of the string so it can be output on the http message
            WriteDate();
            return myData;
        }

        public void WriteDate()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }

        public class ValuesController : ApiController
        {
            //can customize response here if needed
        }



        // POST: api/Main
        public IHttpActionResult Post([FromBody]Something value)
        {
            //forces WebAPI to read a simple type from the request body using the 'FromBody' parameter attribute
            //returns void
            
            return Ok();
        }

        // PUT: api/Main/5
        public void Put(int id, [FromBody]string value)
        {
            //tries to get the value from the request URI for id parameter
            //item parameter is a complex type and reads value from request body (also more secure)
            //returns void
            //preferred use, updates to a specific resource
        }

        // DELETE: api/Main/5
        public void Delete(int id)
        {
        }
    }

    public sealed class Something
    {
        public string type { get; set; }
        public string model { get; set; }
        public string color { get; set; }
    }

    //------------------------
    //Autofac stuff
    //------------------------

    public interface IOutput
    {
        //prototype the output functions here under this interface
        void Write(string content);
    }

    public interface IDateWriter
    {
        void WriteDate();
    }

    public sealed class TodayDate : IDateWriter
    {
        private IOutput _output;
        public TodayDate(IOutput output)
        {
            this._output = output;
        }
        public void WriteDate()
        {
            this._output.Write(DateTime.Today.ToLongDateString());
        }
    }
    
    public sealed class myDateOuput : IOutput
    {
        public void Write(string content)
        {
           //need to return the value when this is called
           //alternatively set the values here
           
        }
    }
}
