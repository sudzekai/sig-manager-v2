using Shared.Types.Errors.ApplicationError;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Exceptions;
using System.Net;

namespace Shared.Utilities.BusinessErrorFactory.Handlers.Internals
{
    public static class InternalErrorsHandler
    {
        private static readonly Dictionary<AppError, BusinessException> _errors = new()
        {
            { InternalErrors.ServiceNotFound, new("Сервис эндпоинта не найден", (int)HttpStatusCode.NotFound) },
            { InternalErrors.ServiceNotImplemented, new("Функциональность эндпоинта не реализована", (int)HttpStatusCode.NotImplemented) }
        };

        public static BusinessException Handle(AppException ex)
            => _errors.GetValueOrDefault(ex.ErrorCode)
            ?? BusinessException.Unknown(ex.ErrorCode.Code);
    }
}