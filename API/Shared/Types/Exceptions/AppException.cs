using Shared.Types.Errors;

namespace Shared.Types.Exceptions
{
    public class AppException : Exception
    {
        public AppException(ErrorCode errorCode) : base()
        {
            ErrorCode = errorCode;
        }

        public AppException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCode ErrorCode { get; }
    }
}
