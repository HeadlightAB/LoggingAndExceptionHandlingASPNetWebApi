using System;
using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Logging
{
    public class Logger
    {
        private static Logger _instance;

        private Logger() {}

        public void BeginRequest(HttpActionContext actionContext, Guid correlationId)
        {
            var method = actionContext.Request.Method;
            var user = actionContext.RequestContext.Principal.Identity.IsAuthenticated
                ? actionContext.RequestContext.Principal.Identity.Name
                : "anonynous";
            var url = actionContext.Request.RequestUri;

            Debug.WriteLine($"BeginRequest logging: {correlationId} - {method} @ {url} by {user}");
        }

        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void EndRequest(HttpActionExecutedContext actionExecutedContext, string correlationId)
        {
            var statusCode = actionExecutedContext.Response.StatusCode;

            Debug.WriteLine($"EndRequest logging: {correlationId} - response is {statusCode}");
        }
    }
}
