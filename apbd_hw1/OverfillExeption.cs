namespace apbd_hw1;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}