using Shared.Types.Exceptions;
using Shared.Utilities.BusinessErrorFactory.Handlers.Entities;
using Shared.Utilities.BusinessErrorFactory.Handlers.Internals;
using Shared.Utilities.BusinessErrorFactory.Handlers.Objects;
using System.Net;

namespace Shared.Utilities.BusinessErrorFactory
{
    public class BusinessErrorFactory
    {
        public static BusinessException ToBusinessException(AppException ex)
        {
            int prefix = ex.Error.GetCodePrefix();

            return prefix switch
            {
                1 => HandleInternalError(ex),
                2 => HandleEntitityError(ex),
                3 => HandleObjectError(ex),
                _ => new($"Неизвестная ошибка сервера. Код ошибки: {ex.Error.Code}", (int)HttpStatusCode.InternalServerError)
            };
        }

        private static BusinessException HandleInternalError(AppException ex)
            => InternalErrorsHandler.Handle(ex);

        private static BusinessException HandleEntitityError(AppException ex)
            => EntityErrorsHandler.Handle(ex);

        private static BusinessException HandleObjectError(AppException ex)
        {
            int entity = ex.Error.GetCodeEntity();

            if (entity is 12)
                return UserObjectErrorsHandler.Handle(ex);

            if (entity is 2)
                return RoleObjectErrorsHandler.Handle(ex);

            return BusinessException.Unknown(ex.Error.Code);
        }
    }
}
