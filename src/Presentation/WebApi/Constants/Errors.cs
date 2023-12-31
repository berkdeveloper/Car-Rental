using Domain.Primitives;

namespace WebApi.Constants;

internal static class Errors
{
    internal static Error UnProcessableRequest => new(
           "API.UnProcessableRequest",
           "The server could not process the request.");

    internal static Error ServerError => new("API.ServerError", "The server encountered an unrecoverable error.");
}
