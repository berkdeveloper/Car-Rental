using Core.Application.Common.Exceptions;
using Core.Domain.Core;
using Core.Domain.Primitives;
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
        var unitOfWork = httpContext.RequestServices.GetService<IUnitOfWork>();

        if (unitOfWork?.HasTransaction == true) await unitOfWork.RollbackTransactionAsync();

        var exceptionHandler = GetHttpStatusCodeAndError(exception);

        string response;

        if (exceptionHandler.Error is not null)
            response = GetResponseAsString(httpContext, exceptionHandler.HttpStatusCode, exceptionHandler.Error);
        else
        {
            (HttpStatusCode httpStatusCode, IReadOnlyCollection<Error> errors) = GetHttpStatusCodeAndErrors(exception);
            response = GetResponseAsString(httpContext, httpStatusCode, errors);
        }

        await httpContext.Response.WriteAsync(response);
    }

    private static (HttpStatusCode HttpStatusCode, IReadOnlyCollection<Error> Errors) GetHttpStatusCodeAndErrors(Exception exception) =>
            exception switch
            {
                ValidationException validationException => (HttpStatusCode.BadRequest, validationException.Errors),
                _ => (HttpStatusCode.InternalServerError, new[] { Errors.ServerError })
            };

    private static (HttpStatusCode HttpStatusCode, Error @Error) GetHttpStatusCodeAndError(Exception exception) =>
              exception switch
              {
                  ConflictException conflictException => (HttpStatusCode.Conflict, new Error(nameof(HttpStatusCode.Conflict), conflictException.Message)),
                  _ => (HttpStatusCode.InternalServerError, Errors.None)
              };

    private static string GetResponseAsString(HttpContext httpContext, HttpStatusCode httpStatusCode, Error error)
    {
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = (int)httpStatusCode;

        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Serialize(new ApiErrorResponse(error), serializerOptions);
    }

    private static string GetResponseAsString(HttpContext httpContext, HttpStatusCode httpStatusCode, IReadOnlyCollection<Error> errors)
    {
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = (int)httpStatusCode;

        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Serialize(new ApiErrorResponse(errors), serializerOptions);
    }

}
