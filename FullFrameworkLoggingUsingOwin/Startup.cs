using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FullFrameworkLoggingUsingOwin.Startup))]

namespace FullFrameworkLoggingUsingOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // Add logging middleware, before webapi
            app.UseLoggingMiddleware();

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
