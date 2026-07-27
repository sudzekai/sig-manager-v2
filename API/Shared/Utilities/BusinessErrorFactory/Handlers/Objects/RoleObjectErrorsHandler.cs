using Shared.Types.Exceptions;

namespace Shared.Utilities.BusinessErrorFactory.Handlers.Objects
{
    public static class RoleObjectErrorsHandler
    {
        public static BusinessException Handle(AppException ex)
        {
            var err = ex.ErrorCode;

            return BusinessException.Unknown(err.Code);
        }
    }
}
