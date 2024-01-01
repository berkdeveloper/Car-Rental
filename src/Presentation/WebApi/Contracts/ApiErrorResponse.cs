using Core.Domain.Primitives;

namespace WebApi.Contracts;

public class ApiErrorResponse
{
    public ApiErrorResponse(IReadOnlyCollection<Error> errors) => Errors = errors;
    public ApiErrorResponse(Error error) => Error = error;

    public IReadOnlyCollection<Error> Errors { get; }
    public Error Error { get; }
}
