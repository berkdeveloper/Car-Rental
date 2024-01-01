using Core.Domain.Primitives;

namespace WebApi.Constants;

internal static class Errors
{
    internal static Error UnProcessableRequest => new(
           "API.UnProcessableRequest",
           "The server could not process the request.");

    internal static Error ServerError => new("API.ServerError", "The server encountered an unrecoverable error.");

    internal static Error Conflict => new("API.Conflict", "Your request could not be processed due to a conflict on the server.");

    internal static Error None => null;
}
