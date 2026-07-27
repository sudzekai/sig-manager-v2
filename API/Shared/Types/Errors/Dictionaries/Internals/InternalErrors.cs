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
        }

        public static readonly AppError Unknown =                   AppErrorFactory.CreateUnknown("INTERNAL",                           1_00);

        public static readonly AppError ErrorCodeAlreadyExists =    AppErrorFactory.CreateAlreadyExists("INTERNAL.ERROR_CODE",          1_01);
        public static readonly AppError ErrorKeyAlreadyExists =     AppErrorFactory.CreateAlreadyExists("INTERNAL.ERROR_KEY",           1_02);

        public static readonly AppError ConfigVariableNotFound =    AppErrorFactory.CreateNotFound("INTERNAL.CONFIGURATION_VARIABLE",   1_03);

        public static readonly AppError ServiceNotFound =           AppErrorFactory.CreateNotFound("INTERNAL.SERVICE",                  1_04);
        public static readonly AppError ServiceNotImplemented =     AppErrorFactory.CreateNotImplemented("INTERNAL.SERVICE",            1_04);
    }
}
