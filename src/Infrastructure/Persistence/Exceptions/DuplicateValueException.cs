namespace Persistence.Exceptions;

public class DuplicateValueException : RepositoryException
{
    public DuplicateValueException(string message, Exception inner = null) : base(message, inner)
    {
    }
}