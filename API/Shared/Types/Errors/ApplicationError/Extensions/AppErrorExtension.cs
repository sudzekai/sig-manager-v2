using Shared.Types.Exceptions;

namespace Shared.Types.Errors.ApplicationError.Extensions
{
    public static class AppErrorExtension
    {
        public static T OrThrowIfNull<T>(this T? val, AppError err)
            => val ?? throw new AppException(err);

        public static T OrThrowIfNull<T>(this T? val, AppError err, string message)
            => val ?? throw new AppException(err, message);

        public static void ThrowIfTrue(this bool val, AppError err)
        {
            if (val)
                throw new AppException(err);
        }

        public static void ThrowIfTrue(this bool val, AppError err, string message)
        {
            if (val)
                throw new AppException(err,message);
        }

        public static void ThrowIfFalse(this bool val, AppError err)
        {
            if (!val)
                throw new AppException(err);
        }

        public static void ThrowIfFalse(this bool val, AppError err, string message)
        {
            if (!val)
                throw new AppException(err,message);
        }

        public static void ThrowIfNotNull(this object? val, AppError err)
        {
            if (val is not null)
                throw new AppException(err);
        }

        public static void ThrowIfNotNull(this object? val, AppError err, string message)
        {
            if (val is not null)
                throw new AppException(err, message);
        }

        public static void Throw(this AppError err)
            => throw new AppException(err);

        public static void Throw(this AppError err, string message)
            => throw new AppException(err, message);
    }
}
