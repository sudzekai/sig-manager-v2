using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности Park
    /// 
    /// <para>Сущность ошибок - 02</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - Name</br>
    /// </summary>
    public class ParkObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = ParkIdIsToSmall;

            _ = ParkNameIsRequired;
            _ = ParkNameIsInvalid;
            _ = ParkNameIsInvalidLength;
            _ = ParkNameIsInvalidFormat;
            _ = ParkNameIsInvalidTooLarge;
            _ = ParkNameIsInvalidTooSmall;
        }

        // parkid = 1
        public static readonly AppError ParkIdIsToSmall =               AppErrorFactory.CreateTooSmall($"OBJECT.PARK_ID",           3_02_01);

        // parkname = 2
        public static readonly AppError ParkNameIsRequired =            AppErrorFactory.CreateRequired($"OBJECT.PARK_NAME",         3_02_02);
        public static readonly AppError ParkNameIsInvalid =             AppErrorFactory.CreateInvalid($"OBJECT.PARK_NAME",          3_02_02);
        public static readonly AppError ParkNameIsInvalidLength =       AppErrorFactory.CreateInvalidLength($"OBJECT.PARK_NAME",    3_02_02);
        public static readonly AppError ParkNameIsInvalidFormat =       AppErrorFactory.CreateInvalidFormat($"OBJECT.PARK_NAME",    3_02_02);
        public static readonly AppError ParkNameIsInvalidTooLarge =     AppErrorFactory.CreateTooLarge($"OBJECT.PARK_NAME",         3_02_02);
        public static readonly AppError ParkNameIsInvalidTooSmall =     AppErrorFactory.CreateTooSmall($"OBJECT.PARK_NAME",         3_02_02);
    }
}
