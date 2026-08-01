using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Internals
{
    /// <summary>
    /// Класс-словарь с внутренними ошибками сервера
    /// 
    /// <para>Префикс ошибок - 1</para>
    /// 
    /// </summary>
    public static class InternalErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = Unknown;

            _ = ErrorCodeAlreadyExists;
            _ = ErrorKeyAlreadyExists;

            _ = ConfigVariableNotFound;

            _ = ServiceNotFound;
            _ = ServiceNotImplemented;

            _ = DependencyNotImplemented;

            _ = RightCodeAlreadyExists;
            _ = RightKeyAlreadyExists;
        }

        public static readonly AppError Unknown =                   AppErrorFactory.CreateUnknown("INTERNAL",                           1_00_000);

        public static readonly AppError ErrorCodeAlreadyExists =    AppErrorFactory.CreateAlreadyExists("INTERNAL.APP_ERROR.CODE",      1_01_01);
        public static readonly AppError ErrorKeyAlreadyExists =     AppErrorFactory.CreateAlreadyExists("INTERNAL.APP_ERROR.KEY",       1_01_02);

        public static readonly AppError ConfigVariableNotFound =    AppErrorFactory.CreateNotFound("INTERNAL.CONFIGURATION_VARIABLE",   1_02_00);

        public static readonly AppError ServiceNotFound =           AppErrorFactory.CreateNotFound("INTERNAL.SERVICE",                  1_03_00);
        public static readonly AppError ServiceNotImplemented =     AppErrorFactory.CreateNotImplemented("INTERNAL.SERVICE",            1_03_00);

        public static readonly AppError DependencyNotImplemented =  AppErrorFactory.CreateNotImplemented("INTERNAL.DEPENDENCY",         1_04_00);

        public static readonly AppError RightCodeAlreadyExists =    AppErrorFactory.CreateAlreadyExists("INTERNAL.RIGHT.CODE",          1_05_01);
        public static readonly AppError RightCodeExistingConflict = AppErrorFactory.CreateConflict("INTERNAL.RIGHT.CODE",               1_05_01);
        public static readonly AppError RightKeyAlreadyExists =     AppErrorFactory.CreateAlreadyExists("INTERNAL.RIGHT.KEY",           1_05_02);
    }
}
