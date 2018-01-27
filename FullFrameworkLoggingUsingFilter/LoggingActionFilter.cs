using System;
using System.Linq;
using System.Net.Http;
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
                var correlationId = Guid.NewGuid();
                AddCorrelartionId(actionContext.Request, correlationId);

                // Logging goes here
                Logger.Instance.BeginRequest(actionContext, correlationId);
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
              Logger.Instance.EndRequest(actionExecutedContext, GetCorrelationId(actionExecutedContext.Request));
            }
            catch
            {
                // ignored, logging should not make the api die
            }

            base.OnActionExecuted(actionExecutedContext);
        }

        private string GetCorrelationId(HttpRequestMessage request)
        {
            return request.Headers.GetValues(XCorrelationHeader).FirstOrDefault();
        }

        private void AddCorrelartionId(HttpRequestMessage request, Guid correlationId)
        {
            request.Headers.Add(XCorrelationHeader, correlationId.ToString());
        }
    }
}