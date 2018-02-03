using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCoreLogging
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        private const string XCorrelationHeader = "x-correlation";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var correlationId = Guid.NewGuid();
                AddCorrelartionId(context.HttpContext.Request, correlationId);

                var request = context.HttpContext.Request;

                var user = context.HttpContext.User.Identity.IsAuthenticated ? context.HttpContext.User.Identity.Name : "anonymous";

                // Logging goes here
                Debug.WriteLine($"[FILTER] BeginRequest logging: {correlationId} - {request.Method} @ {request.Path} by {user}");
            }
            catch
            {
                // ignored, logging should not make the api die
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                var statusCode = context.HttpContext.Response.StatusCode;

                // Logging goes here
                Debug.WriteLine($"[FILTER] EndRequest logging: {GetCorrelationId(context.HttpContext.Request)} - response is {statusCode}");
            }
            catch
            {
                // ignored, logging should not make the api die
            }

            base.OnActionExecuted(context);
        }

        private string GetCorrelationId(HttpRequest request)
        {
            return request.Headers[XCorrelationHeader].ToString();
        }

        private void AddCorrelartionId(HttpRequest request, Guid correlationId)
        {
            request.Headers.Add(XCorrelationHeader, correlationId.ToString());
        }
    }
}