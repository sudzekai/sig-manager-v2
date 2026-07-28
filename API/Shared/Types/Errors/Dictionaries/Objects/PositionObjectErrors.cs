using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности Position
    /// 
    /// <para>Сущность ошибок - 03</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - Name</br>
    /// <br>03 - PricePerHour</br>
    /// </summary>
    public class PositionObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = PositionIdIsToSmall;

            _ = PositionNameIsRequired;
            _ = PositionNameIsInvalid;
            _ = PositionNameIsInvalidLength;
            _ = PositionNameIsInvalidFormat;
            _ = PositionNameIsInvalidTooLarge;
            _ = PositionNameIsInvalidTooSmall;

            _ = PricePerHourIsRequired;
            _ = PricePerHourIsInvalid;
            _ = PricePerHourIsInvalidLength;
            _ = PricePerHourIsInvalidFormat;
            _ = PricePerHourIsInvalidTooLarge;
            _ = PricePerHourIsInvalidTooSmall;
        }

        // positionid = 1
        public static readonly AppError PositionIdIsToSmall =               AppErrorFactory.CreateTooSmall($"OBJECT.POSITION_ID",                   3_03_01);

        // positionname = 2
        public static readonly AppError PositionNameIsRequired =            AppErrorFactory.CreateRequired($"OBJECT.POSITION_NAME",                 3_03_02);
        public static readonly AppError PositionNameIsInvalid =             AppErrorFactory.CreateInvalid($"OBJECT.POSITION_NAME",                  3_03_02);
        public static readonly AppError PositionNameIsInvalidLength =       AppErrorFactory.CreateInvalidLength($"OBJECT.POSITION_NAME",            3_03_02);
        public static readonly AppError PositionNameIsInvalidFormat =       AppErrorFactory.CreateInvalidFormat($"OBJECT.POSITION_NAME",            3_03_02);
        public static readonly AppError PositionNameIsInvalidTooLarge =     AppErrorFactory.CreateTooLarge($"OBJECT.POSITION_NAME",                 3_03_02);
        public static readonly AppError PositionNameIsInvalidTooSmall =     AppErrorFactory.CreateTooSmall($"OBJECT.POSITION_NAME",                 3_03_02);

        // priceperhour = 3
        public static readonly AppError PricePerHourIsRequired =            AppErrorFactory.CreateRequired($"OBJECT.POSITION_PRICE_PER_HOUR",       3_03_03);
        public static readonly AppError PricePerHourIsInvalid =             AppErrorFactory.CreateInvalid($"OBJECT.POSITION_PRICE_PER_HOUR",        3_03_03);
        public static readonly AppError PricePerHourIsInvalidLength =       AppErrorFactory.CreateInvalidLength($"OBJECT.POSITION_PRICE_PER_HOUR",  3_03_03);
        public static readonly AppError PricePerHourIsInvalidFormat =       AppErrorFactory.CreateInvalidFormat($"OBJECT.POSITION_PRICE_PER_HOUR",  3_03_03);
        public static readonly AppError PricePerHourIsInvalidTooLarge =     AppErrorFactory.CreateTooLarge($"OBJECT.POSITION_PRICE_PER_HOUR",       3_03_03);
        public static readonly AppError PricePerHourIsInvalidTooSmall =     AppErrorFactory.CreateTooSmall($"OBJECT.POSITION_PRICE_PER_HOUR",       3_03_03);
    }
}
