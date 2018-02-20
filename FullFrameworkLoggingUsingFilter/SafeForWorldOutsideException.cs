﻿using System;
using System.Net;

namespace FullFrameworkLoggingUsingFilter
{
    public class SafeForWorldOutsideException : Exception, IExceptionForOutsideWorld
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
        public override string Message => "This error is for demo purposes";
    }
}