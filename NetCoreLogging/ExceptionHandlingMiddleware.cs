using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace NetCoreLogging
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                if (exception is IExceptionForOutsideWorld responseException)
                {
                    context.Response.Clear();
                    context.Response.StatusCode = (int) responseException.HttpStatusCode;
                    context.Response.ContentType = MediaTypeNames.Text.Plain;

                    await context.Response.WriteAsync(responseException.Message);
                }
            }
        }
    }
}