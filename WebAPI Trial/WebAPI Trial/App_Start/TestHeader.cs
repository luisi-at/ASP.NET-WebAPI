using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Threading;


/// <summary>
/// HTTP Message Handler Tryout
/// </summary>
public class MessageHandler1 : DelegatingHandler
{
    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        
        Debug.WriteLine("Process Request");
        string myDataString = "DATA";
        var dataTest = "Data test 123";
        IEnumerable<string> responseValues = null;
        string singleResponse = null;

        //request.Headers.Add("NewHeader", "NEW!");
        if (request.Headers.Contains("Test-Header")) //can even use this method with user/request body input as just use a variable
        {
            responseValues = request.Headers.GetValues("Test-Header"); //note that this returns an array
            singleResponse = responseValues.FirstOrDefault().ToString(); //return the first or default value for the header
        }

        CallContext.LogicalSetData(myDataString, dataTest);
        //AsyncLocal<string> 
        var response = await base.SendAsync(request, cancellationToken);
        Debug.WriteLine("Process Reponse");
        response.Headers.Add("NewHeaderFromRequest", singleResponse);
        return response;
    }
}
