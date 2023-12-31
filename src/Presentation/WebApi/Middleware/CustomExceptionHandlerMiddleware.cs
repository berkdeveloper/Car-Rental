using Application.Common.Exceptions;
using Domain.Primitives;
using System.Net;
using System.Text.Json;
using WebApi.Constants;
using WebApi.Contracts;

namespace WebApi.Middleware;

internal class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

    public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        (HttpStatusCode httpStatusCode, IReadOnlyCollection<Error> errors) = GetHttpStatusCodeAndErrors(exception);

        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = (int)httpStatusCode;

        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        string response = JsonSerializer.Serialize(new ApiErrorResponse(errors), serializerOptions);

        await httpContext.Response.WriteAsync(response);
    }

    private static (HttpStatusCode HttpStatusCode, IReadOnlyCollection<Error> Errors) GetHttpStatusCodeAndErrors(Exception exception) =>
            exception switch
            {
                ValidationException validationException => (HttpStatusCode.BadRequest, validationException.Errors),
                _ => (HttpStatusCode.InternalServerError, new[] { Errors.ServerError })
            };

}
