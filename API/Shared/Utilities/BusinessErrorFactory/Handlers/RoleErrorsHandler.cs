using Shared.Types.Exceptions;

namespace Shared.Utilities.BusinessErrorFactory.Handlers
{
    public static class RoleErrorsHandler
    {
        public static BusinessException Handle(AppException ex)
        {
            var err = ex.ErrorCode;

            return BusinessException.Unknown;
        }
    }
}
