using Shared.Types.Errors;

namespace Shared.Types.Exceptions
{
    public class AppException(ErrorCode errorCode) : Exception
    {
        public ErrorCode ErrorCode { get; } = errorCode;
    }
}
