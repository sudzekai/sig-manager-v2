using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Exceptions
{
    public class AppException : Exception
    {
        public AppException(AppError errorCode) : base()
        {
            Error = errorCode;
        }

        public AppException(AppError errorCode, string message) : base(message)
        {
            Error = errorCode;
        }

        public AppError Error { get; }

        public void Throw()
            => throw this;
    }
}
