﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace FullFrameworkLoggingUsingOwin
{
    public class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next) : base(next)
        {}

        public override async Task Invoke(IOwinContext context)
        {
            var correlationId = Guid.NewGuid().ToString();

            var request = context.Request;

            var user = context.Request.User.Identity.IsAuthenticated
                ? context.Request.User.Identity.Name
                : "anonymous";

            Debug.WriteLine($"BeginRequest logging: {correlationId} - {request.Method} @ {request.Uri} by {user}");

            await Next.Invoke(context);

            Debug.WriteLine($"EndRequest logging: {correlationId} - response is {context.Response.StatusCode} {context.Response.ReasonPhrase}");
        }
    }
}