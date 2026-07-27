using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности User
    /// 
    /// <para>Префикс ошибок - 1</para>
    /// </summary>
    public class RoleObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = RoleIdIsToSmall;
        }

        public static readonly AppError RoleIdIsToSmall = AppErrorFactory.CreateTooSmall($"OBJECT.ROLE_ID", 2_08);
    }
}
