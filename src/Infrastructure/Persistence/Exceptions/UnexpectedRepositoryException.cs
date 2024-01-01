namespace Persistence.Exceptions;

public class UnexpectedRepositoryException : RepositoryException
{
    public UnexpectedRepositoryException(string message, Exception inner) : base(message, inner)
    {
    }
    public UnexpectedRepositoryException(Exception inner = null) : base("An unexpected database error has occurred.", inner)
    {
    }
}