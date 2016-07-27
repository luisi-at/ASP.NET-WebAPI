using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Runtime.Remoting.Messaging;

namespace WebAPI_Trial.Controllers
{
    public class MainController : ApiController
    {
        // GET: api/Main
        public Something Get()
        {
            //need to return json somehow here
            return new Something { type = "SomeType", model = "SomeModel", color = "Colour" };
        }

        // GET: api/Main/5
        public string Get(int id)
        {
            //CallContext.LogicalSetData("MyData", "Some Data");
            
            var myData = CallContext.LogicalGetData("DATA");
            return myData.ToString();
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
}
