namespace Presentation.Internal.Objects
{
    internal class Error(int code, string message)
    {
        public int Code { get; init; } = code;
        public string Message { get; init; } = message;
    }
}
