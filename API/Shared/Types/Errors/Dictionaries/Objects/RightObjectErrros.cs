using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности Right
    /// 
    /// <para>Сущность ошибок - 05</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - Code</br>
    /// </summary>
    public class RightObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = RightIdIsToSmall;

            _ = RightCodeIsRequired;
            _ = RightCodeIsInvalid;
            _ = RightCodeIsInvalidLength;
            _ = RightCodeIsInvalidFormat;
            _ = RightCodeIsInvalidTooLarge;
            _ = RightCodeIsInvalidTooSmall;
        }

        // rightid = 1
        public static readonly AppError RightIdIsToSmall =               AppErrorFactory.CreateTooSmall($"OBJECT.RIGHT_ID",           3_05_01);

        // rightcode = 2
        public static readonly AppError RightCodeIsRequired =            AppErrorFactory.CreateRequired($"OBJECT.RIGHT_CODE",         3_05_02);
        public static readonly AppError RightCodeIsInvalid =             AppErrorFactory.CreateInvalid($"OBJECT.RIGHT_CODE",          3_05_02);
        public static readonly AppError RightCodeIsInvalidLength =       AppErrorFactory.CreateInvalidLength($"OBJECT.RIGHT_CODE",    3_05_02);
        public static readonly AppError RightCodeIsInvalidFormat =       AppErrorFactory.CreateInvalidFormat($"OBJECT.RIGHT_CODE",    3_05_02);
        public static readonly AppError RightCodeIsInvalidTooLarge =     AppErrorFactory.CreateTooLarge($"OBJECT.RIGHT_CODE",         3_05_02);
        public static readonly AppError RightCodeIsInvalidTooSmall =     AppErrorFactory.CreateTooSmall($"OBJECT.RIGHT_CODE",         3_05_02);
    }
}
