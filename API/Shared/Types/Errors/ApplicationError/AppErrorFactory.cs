using Shared.Internal;
using Shared.Types.Errors.ApplicationError.Dictionaries;

namespace Shared.Types.Errors.ApplicationError
{
    internal static class AppErrorFactory
    {
        public static AppError CreateUnknown(string key, int code)
        {
            code = $"{code}{ErrorCodes.Unknown}".ToInt();
            key = $"{key}.{ErrorKeys.Unknown}";
            return AppError.Create(key, code);
        }

        public static AppError CreateRequired(string key, int code)
        {
            code = $"{code}{ErrorCodes.Required}".ToInt();
            key = $"{key}.{ErrorKeys.Required}";
            return AppError.Create(key, code);
        }

        public static AppError CreateInvalid(string key, int code)
        {
            code = $"{code}{ErrorCodes.Invalid}".ToInt();
            key = $"{key}.{ErrorKeys.Invalid}";
            return AppError.Create(key, code);
        }

        public static AppError CreateInvalidLength(string key, int code)
        {
            code = $"{code}{ErrorCodes.InvalidLength}".ToInt();
            key = $"{key}.{ErrorKeys.InvalidLength}";
            return AppError.Create(key, code);
        }

        public static AppError CreateInvalidFormat(string key, int code)
        {
            code = $"{code}{ErrorCodes.InvalidFormat}".ToInt();
            key = $"{key}.{ErrorKeys.InvalidFormat}";
            return AppError.Create(key, code);
        }

        public static AppError CreateOutOfRange(string key, int code)
        {
            code = $"{code}{ErrorCodes.OutOfRange}".ToInt();
            key = $"{key}.{ErrorKeys.OutOfRange}";
            return AppError.Create(key, code);
        }

        public static AppError CreateTooSmall(string key, int code)
        {
            code = $"{code}{ErrorCodes.TooSmall}".ToInt();
            key = $"{key}.{ErrorKeys.TooSmall}";
            return AppError.Create(key, code);
        }

        public static AppError CreateTooLarge(string key, int code)
        {
            code = $"{code}{ErrorCodes.TooLarge}".ToInt();
            key = $"{key}.{ErrorKeys.TooLarge}";
            return AppError.Create(key, code);
        }

        public static AppError CreateUnauthorized(string key, int code)
        {
            code = $"{code}{ErrorCodes.Unauthorized}".ToInt();
            key = $"{key}.{ErrorKeys.Unauthorized}";
            return AppError.Create(key, code);
        }

        public static AppError CreateForbidden(string key, int code)
        {
            code = $"{code}{ErrorCodes.Forbidden}".ToInt();
            key = $"{key}.{ErrorKeys.Forbidden}";
            return AppError.Create(key, code);
        }

        public static AppError CreateInvalidState(string key, int code)
        {
            code = $"{code}{ErrorCodes.InvalidState}".ToInt();
            key = $"{key}.{ErrorKeys.InvalidState}";
            return AppError.Create(key, code);
        }

        public static AppError CreateExpired(string key, int code)
        {
            code = $"{code}{ErrorCodes.Expired}".ToInt();
            key = $"{key}.{ErrorKeys.Expired}";
            return AppError.Create(key, code);
        }

        public static AppError CreateDisabled(string key, int code)
        {
            code = $"{code}{ErrorCodes.Disabled}".ToInt();
            key = $"{key}.{ErrorKeys.Disabled}";
            return AppError.Create(key, code);
        }

        public static AppError CreateLocked(string key, int code)
        {
            code = $"{code}{ErrorCodes.Locked}".ToInt();
            key = $"{key}.{ErrorKeys.Locked}";
            return AppError.Create(key, code);
        }

        public static AppError CreateNotFound(string key, int code)
        {
            code = $"{code}{ErrorCodes.NotFound}".ToInt();
            key = $"{key}.{ErrorKeys.NotFound}";
            return AppError.Create(key, code);
        }

        public static AppError CreateAlreadyExists(string key, int code)
        {
            code = $"{code}{ErrorCodes.AlreadyExists}".ToInt();
            key = $"{key}.{ErrorKeys.AlreadyExists}";
            return AppError.Create(key, code);
        }

        public static AppError CreateConflict(string key, int code)
        {
            code = $"{code}{ErrorCodes.Conflict}".ToInt();
            key = $"{key}.{ErrorKeys.Conflict}";
            return AppError.Create(key, code);
        }

        public static AppError CreateInUse(string key, int code)
        {
            code = $"{code}{ErrorCodes.InUse}".ToInt();
            key = $"{key}.{ErrorKeys.InUse}";
            return AppError.Create(key, code);
        }

        public static AppError CreateLimitExceeded(string key, int code)
        {
            code = $"{code}{ErrorCodes.LimitExceeded}".ToInt();
            key = $"{key}.{ErrorKeys.LimitExceeded}";
            return AppError.Create(key, code);
        }

        public static AppError CreateExternalServiceError(string key, int code)
        {
            code = $"{code}{ErrorCodes.ExternalServiceError}".ToInt();
            key = $"{key}.{ErrorKeys.ExternalServiceError}";
            return AppError.Create(key, code);
        }

        public static AppError CreateDatabaseError(string key, int code)
        {
            code = $"{code}{ErrorCodes.DatabaseError}".ToInt();
            key = $"{key}.{ErrorKeys.DatabaseError}";
            return AppError.Create(key, code);
        }

        public static AppError CreateNotImplemented(string key, int code)
        {
            code = $"{code}{ErrorCodes.NotImplemented}".ToInt();
            key = $"{key}.{ErrorKeys.NotImplemented}";
            return AppError.Create(key, code);
        }
    }
}
