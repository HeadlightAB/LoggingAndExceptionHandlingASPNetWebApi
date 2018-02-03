using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace NetCoreLogging
{
    public static class LoggingMiddlewareExtensions
    {
        public static void UseLoggingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingMiddleware>();
        }
    }

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var correlationId = Guid.NewGuid().ToString();

            var request = context.Request;

            var user = context.User.Identity.IsAuthenticated ? context.User.Identity.Name : "anonymous";

            Debug.WriteLine($"BeginRequest logging: {correlationId} - {request.Method} @ {request.Path} by {user}");

            await _next(context);

            Debug.WriteLine($"EndRequest logging: {correlationId} - response is {context.Response.StatusCode}");
        }
    }
}