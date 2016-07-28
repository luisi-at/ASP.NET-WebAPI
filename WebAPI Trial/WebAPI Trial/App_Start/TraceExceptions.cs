using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Handlers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Web.Services;
using System.Diagnostics;

public class TraceExceptions : ExceptionLogger
{
    public override void Log(ExceptionLoggerContext context)
    {
        Trace.TraceError(context.ExceptionContext.Exception.ToString());
    }
}