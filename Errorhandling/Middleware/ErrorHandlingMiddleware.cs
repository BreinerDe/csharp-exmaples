using System;
using System.Threading.Tasks;
using ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ErrorHandling.Middleware
{
    internal class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ProblemDetailsExceptionHandler problemDetailsExceptionHandler;
        private readonly DefaultExceptionHandler defaultExceptionHandler;

        public ErrorHandlingMiddleware(ProblemDetailsExceptionHandler problemDetailsExceptionHandler, DefaultExceptionHandler defaultExceptionHandler)
        {
            this.problemDetailsExceptionHandler = problemDetailsExceptionHandler;
            this.defaultExceptionHandler = defaultExceptionHandler;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context).ConfigureAwait(false);
            }
            catch (ProblemDetailsException exception)
            {
                await problemDetailsExceptionHandler.HandleAsync(context, exception).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                await defaultExceptionHandler.HandleAsync(context, exception).ConfigureAwait(false);
            }
        }

    }
}