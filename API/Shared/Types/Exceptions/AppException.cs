using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Exceptions
{
    public class AppException : Exception
    {
        public AppException(AppError errorCode) : base()
        {
            ErrorCode = errorCode;
        }

        public AppException(AppError errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public AppError ErrorCode { get; }

        public void Throw()
            => throw this;
    }
}
