using Shared.Types.Exceptions;
using Shared.Utilities.BusinessErrorFactory.Handlers;

namespace Shared.Utilities.BusinessErrorFactory
{
    public class BusinessErrorFactory
    {
        public static BusinessException ToBusinessException(AppException ex)
        {
            int entity = ex.ErrorCode.Code / 1_00_00;

            return entity switch
            {
                2 => UserErrorsHandler.Handle(ex),
                3 => RoleErrorsHandler.Handle(ex),
                _ => InternalErrorsHandler.Handle(ex)
            };
        }
    }
}
