namespace Application.Exceptions;

public class UnknownUserException : Exception
{
    public UnknownUserException()
    { }

    public UnknownUserException(string message) 
        : base(message)
    { }

    public UnknownUserException(string message, Exception innerException)
        : base(message, innerException)
    { }
}