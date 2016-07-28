using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Handlers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Web.Services;


public class CentralExceptionHandler : ExceptionHandler
{

    public override void Handle(ExceptionHandlerContext myContext)
    {

        myContext.Result = new TextPlainErrorResult
        {
            Request = myContext.ExceptionContext.Request,
            myContent = "Something Went Wrong"

        };

    }

    private class TextPlainErrorResult : IHttpActionResult
    {

        public HttpRequestMessage Request { get; set; }

        public string myContent { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken myCancelToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            response.Content = new StringContent(myContent);
            response.RequestMessage = Request;
            return Task.FromResult(response);

        }
    }
}