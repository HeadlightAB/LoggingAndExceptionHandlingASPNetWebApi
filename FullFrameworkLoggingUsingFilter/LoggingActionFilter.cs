using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FullFrameworkLoggingUsingFilter
{
    public class LoggingActionFilter : ActionFilterAttribute
    {
        private const string XCorrelationHeader = "x-correlation";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                // Logging goes here
                var method = actionContext.Request.Method;
                var user = actionContext.RequestContext.Principal.Identity;
                var url = actionContext.Request.RequestUri;
                actionContext.Request.Headers.Add(XCorrelationHeader, Guid.NewGuid().ToString());
            }
            catch
            {
                // ignored, logging should not make the api die
            }

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                // Logging goes here
                var statusCode = actionExecutedContext.Response.StatusCode;
                var correlationId = actionExecutedContext.Request.Headers.GetValues(XCorrelationHeader).Single();
            }
            catch
            {
                // ignored, logging should not make the api die
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}