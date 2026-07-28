using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Exceptions
{
    public class AppException : Exception
    {
        public AppException(AppError error) : base()
        {
            Error = error;
        }

        public AppException(AppError errorCode, string message) : base(message)
        {
            Error = errorCode;
        }

        public AppError Error { get; }

        public void Throw()
            => throw this;

        public override string ToString()
            => $"{Error.Code}: {Error.Key} | Message: {Message}";
    }
}
