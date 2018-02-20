using System.Net;

namespace FullFrameworkLoggingUsingFilter
{
    interface IExceptionForOutsideWorld
    {
        HttpStatusCode HttpStatusCode { get; }
        string Message { get; }
    }
}
