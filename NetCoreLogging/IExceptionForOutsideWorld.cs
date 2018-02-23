using System.Net;

namespace NetCoreLogging
{
    interface IExceptionForOutsideWorld
    {
        HttpStatusCode HttpStatusCode { get; }
        string Message { get; }
    }
}