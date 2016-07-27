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
        

        CallContext.LogicalSetData(myDataString, dataTest);
        //AsyncLocal<string> 
        var response = await base.SendAsync(request, cancellationToken);
        Debug.WriteLine("Process Reponse");
        return response;
    }
}
