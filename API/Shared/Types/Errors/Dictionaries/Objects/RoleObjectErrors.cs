using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности Role
    /// 
    /// <para>Сущность ошибок - 06</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - Name</br>
    /// </summary>
    public class RoleObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = RoleIdIsToSmall;

            _ = RoleNameIsRequired;
            _ = RoleNameIsInvalid;
            _ = RoleNameIsInvalidLength;
            _ = RoleNameIsInvalidFormat;
            _ = RoleNameIsInvalidTooLarge;
            _ = RoleNameIsInvalidTooSmall;
        }

        // roleid = 1
        public static readonly AppError RoleIdIsToSmall =               AppErrorFactory.CreateTooSmall($"OBJECT.ROLE_ID",           3_06_01);

        // rolename = 2
        public static readonly AppError RoleNameIsRequired =            AppErrorFactory.CreateRequired($"OBJECT.ROLE_NAME",         3_06_02);
        public static readonly AppError RoleNameIsInvalid =             AppErrorFactory.CreateInvalid($"OBJECT.ROLE_NAME",          3_06_02);
        public static readonly AppError RoleNameIsInvalidLength =       AppErrorFactory.CreateInvalidLength($"OBJECT.ROLE_NAME",    3_06_02);
        public static readonly AppError RoleNameIsInvalidFormat =       AppErrorFactory.CreateInvalidFormat($"OBJECT.ROLE_NAME",    3_06_02);
        public static readonly AppError RoleNameIsInvalidTooLarge =     AppErrorFactory.CreateTooLarge($"OBJECT.ROLE_NAME",         3_06_02);
        public static readonly AppError RoleNameIsInvalidTooSmall =     AppErrorFactory.CreateTooSmall($"OBJECT.ROLE_NAME",         3_06_02);
    }
}
