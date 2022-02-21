using System.Net.Mime;
using System.Threading.Tasks;
using LinkShortener.Models.Common;
using LinkShortener.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace LinkShortener.Core.Infrastructure.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (LinkShortenerValidationException exception)
            {
                await WriteBadRequestStatusResponseAsync(httpContext, exception);
            }
        }

        private static async Task WriteBadRequestStatusResponseAsync(HttpContext httpContext,
            LinkShortenerValidationException exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            await httpContext.Response.WriteAsJsonAsync(new ResponseModel<BadRequestValidationFailedModel>(
                new BadRequestValidationFailedModel
                {
                    ValidationFailures = exception.ValidationFailures
                }));
        }
    }
}