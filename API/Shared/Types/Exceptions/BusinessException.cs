using System.Net;

namespace Shared.Types.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message, int code) : base(message)
        {
            Code = code;
        } 

        public int Code { get; }

        public static BusinessException Unknown
            => new BusinessException("Непредвиденная ошибка сервера", (int)HttpStatusCode.InternalServerError);
    }
}
