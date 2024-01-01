namespace Persistence.Exceptions;

public class OutOfRangeException : RepositoryException
{
    public OutOfRangeException(string message, Exception inner = null) : base(message, inner)
    {
    }
}