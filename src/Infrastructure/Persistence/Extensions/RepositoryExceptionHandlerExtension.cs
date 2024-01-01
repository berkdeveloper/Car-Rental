using Npgsql;
using Persistence.Exceptions;

namespace Persistence.Extensions;

public static class RepositoryExceptionHandlerExtension
{
    public static RepositoryException Handle(this Exception exception)
    {
        if (exception.GetType() == typeof(PostgresException))
            return PostgresExceptionHandle(exception as PostgresException);

        else if (exception.InnerException?.GetType() == typeof(PostgresException))
            return PostgresExceptionHandle(exception.InnerException as PostgresException);

        else
            return new UnexpectedRepositoryException();
    }

    public static RepositoryException PostgresExceptionHandle(PostgresException postgresException)
    {
        return postgresException.SqlState switch
        {
            PostgresErrorCodes.UniqueViolation => new DuplicateValueException("Duplicate record cannot be added."),
            PostgresErrorCodes.ForeignKeyViolation => new InvalidReferenceException("Reference value is invalid."),
            PostgresErrorCodes.NotNullViolation => new NotNullException("Column value cannot be null."),
            PostgresErrorCodes.NumericValueOutOfRange => new OutOfRangeException("Numeric value cannot be out of range."),
            PostgresErrorCodes.StringDataRightTruncation => new OutOfRangeException("Text value cannot be out of range."),
            _ => new UnexpectedRepositoryException()
        };
    }
}
