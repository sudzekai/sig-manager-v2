using Shared.Types.Errors;
using Shared.Types.Exceptions;
using System.Net;

namespace Shared.Utilities.BusinessErrorFactory.Handlers
{
    public static class InternalErrorsHandler
    {
        public static BusinessException Handle(AppException ex)
        {
            var err = ex.ErrorCode;

            if (err == InternalErrors.ServiceNotFound)
                return new("Функциональность эндпоинта не реализована", (int)HttpStatusCode.NotImplemented);

            return BusinessException.Unknown;
        }
    }
}
