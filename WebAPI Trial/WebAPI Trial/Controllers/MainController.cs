using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Runtime.Remoting.Messaging;
using WebAPI_Trial.Interfaces;
using WebAPI_Trial.Misc_Classes;

//demonstration of WebAPI with Autofac

namespace WebAPI_Trial.Misc_Classes
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

    }
}
