using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ErrorHandling.Exceptions
{
    internal class ProblemDetailsExceptionHandler
    {
        internal Task HandleAsync(HttpContext context, ProblemDetailsException problemDetailsException)
        {
            context.Response.Clear();
            context.Response.ContentType = MediaTypeNames.Application.Json;

            if (problemDetailsException.ProblemDetails.Status != null)
            {
                context.Response.StatusCode = problemDetailsException.ProblemDetails.Status.Value;
            }

            return context.Response.WriteAsJsonAsync(problemDetailsException.ProblemDetails);
        }
    }
}