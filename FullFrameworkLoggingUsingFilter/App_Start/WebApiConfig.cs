using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace FullFrameworkLoggingUsingFilter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());

            // Web API configuration and services
            config.Filters.Add(new LoggingActionFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
