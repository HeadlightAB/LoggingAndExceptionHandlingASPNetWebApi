using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace FullFrameworkLoggingUsingOwin
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var exception = context.Exception;
            if (exception is IExceptionForOutsideWorld)
            {
                var responseException = exception as IExceptionForOutsideWorld;

                context.Result =
                    new ExceptionForOutsideWorldResult(
                        responseException.HttpStatusCode,
                        responseException.Message,
                        context.Request);
            }

            return Task.FromResult(0);
        }
    }
}