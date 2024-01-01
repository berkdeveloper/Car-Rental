namespace Persistence.Exceptions;

public class InvalidReferenceException : RepositoryException
{
    public InvalidReferenceException(string message, Exception inner = null) : base(message, inner)
    {
    }
}