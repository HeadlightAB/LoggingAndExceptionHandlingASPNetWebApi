using System.Net;

namespace FullFrameworkLoggingUsingOwin
{
    interface IExceptionForOutsideWorld
    {
        HttpStatusCode HttpStatusCode { get; }
        string Message { get; }
    }
}