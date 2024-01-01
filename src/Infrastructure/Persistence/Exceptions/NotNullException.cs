namespace Persistence.Exceptions;

public class NotNullException : RepositoryException
{
    public NotNullException(string message, Exception inner = null) : base(message, inner)
    {

    }

    public NotNullException()
    {

    }
}