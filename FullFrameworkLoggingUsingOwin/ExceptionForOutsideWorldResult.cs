using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace FullFrameworkLoggingUsingOwin
{
    public class ExceptionForOutsideWorldResult : IHttpActionResult
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _message;
        private readonly HttpRequestMessage _request;

        public ExceptionForOutsideWorldResult(HttpStatusCode statusCode, string message, HttpRequestMessage request)
        {
            _statusCode = statusCode;
            _message = message;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_request.CreateErrorResponse(_statusCode, _message));
        }
    }
}