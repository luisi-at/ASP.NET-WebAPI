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

        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------
        // Start of Autofac stuff
        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------


        // This integrates Autofac with WebAPI by not using Service Locators
        private readonly IDateWriter _dateWriter;
        public MainController(IDateWriter datewriter)
        {
            // set the variable to hold the value
            _dateWriter = datewriter;
        }
       
        public sealed class TodayDate : IDateWriter
        {
            private IOutput _output;
            public TodayDate(IOutput output)
            {
                // set the variable to hold the value
                _output = output;
            }
            public string WriteDate()
            {
               // get the value to return up the call path
               return DateTime.Today.ToLongDateString();
            }
        }

        public interface IOutput
        {
            //prototype the output functions here under this interface
            string Write(string content);
        }

        public interface IDateWriter
        {
            //method to give the final output that can be invoked by those classes who interface with IDateWriter
            string WriteDate();
        }

        public sealed class DateOutput : IOutput
        {
            public string Write(string content)
            {
                //method to fetch the date and can be invoked by those classes who interface with IOutput
                return content;
            }
        }

        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------
        // End of Autofac stuff
        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------
        // Note: To implement writing a different date, the only thing that needs to be done is create...
        // ...a different IDateWriter Class, such as TomorrowDate and then change the registartion in...
        // ...the application start config file. There is no need to change any existing classes!
        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------


        private static IContainer Container { get; set; }
        // GET: api/Main
        // just to return some values from a class
        public Something Get()
        {
            //throw new ArgumentNullException("Something");
            
            return new Something { Type = "SomeType", Model = "SomeModel", Color = "Colour" };
        }

        // GET: api/Main/5
        public string Get(int id) 
        {
            //invokes the method to return the current date
            var myData = _dateWriter.WriteDate();
            //returns the value
            return myData;
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
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }    
}
