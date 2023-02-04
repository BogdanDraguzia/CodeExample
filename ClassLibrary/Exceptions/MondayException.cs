namespace ClassLibrary.Exceptions;

public class MondayException : Exception
{
    const string ErrorMessage = "Method doesn't work on Mondays";

    public MondayException()
        : base(ErrorMessage)
    { }
}