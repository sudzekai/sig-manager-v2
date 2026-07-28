using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности Product
    /// 
    /// <para>Сущность ошибок - 04</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - Name</br>
    /// <br>03 - Price</br>
    /// </summary>
    public class ProductObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = ProductIdIsToSmall;

            _ = ProductNameIsRequired;
            _ = ProductNameIsInvalid;
            _ = ProductNameIsInvalidLength;
            _ = ProductNameIsInvalidFormat;
            _ = ProductNameIsInvalidTooLarge;
            _ = ProductNameIsInvalidTooSmall;

            _ = ProductPriceIsRequired;
            _ = ProductPriceIsInvalid;
            _ = ProductPriceIsInvalidLength;
            _ = ProductPriceIsInvalidFormat;
            _ = ProductPriceIsInvalidTooLarge;
            _ = ProductPriceIsInvalidTooSmall;
        }

        // productid = 1
        public static readonly AppError ProductIdIsToSmall =                AppErrorFactory.CreateTooSmall($"OBJECT.PRODUCT_ID",            3_04_01);

        // productname = 2
        public static readonly AppError ProductNameIsRequired =             AppErrorFactory.CreateRequired($"OBJECT.PRODUCT_NAME",          3_04_02);
        public static readonly AppError ProductNameIsInvalid =              AppErrorFactory.CreateInvalid($"OBJECT.PRODUCT_NAME",           3_04_02);
        public static readonly AppError ProductNameIsInvalidLength =        AppErrorFactory.CreateInvalidLength($"OBJECT.PRODUCT_NAME",     3_04_02);
        public static readonly AppError ProductNameIsInvalidFormat =        AppErrorFactory.CreateInvalidFormat($"OBJECT.PRODUCT_NAME",     3_04_02);
        public static readonly AppError ProductNameIsInvalidTooLarge =      AppErrorFactory.CreateTooLarge($"OBJECT.PRODUCT_NAME",          3_04_02);
        public static readonly AppError ProductNameIsInvalidTooSmall =      AppErrorFactory.CreateTooSmall($"OBJECT.PRODUCT_NAME",          3_04_02);

        // productprice = 3
        public static readonly AppError ProductPriceIsRequired =            AppErrorFactory.CreateRequired($"OBJECT.PRODUCT_PRICE",         3_04_03);
        public static readonly AppError ProductPriceIsInvalid =             AppErrorFactory.CreateInvalid($"OBJECT.PRODUCT_PRICE",          3_04_03);
        public static readonly AppError ProductPriceIsInvalidLength =       AppErrorFactory.CreateInvalidLength($"OBJECT.PRODUCT_PRICE",    3_04_03);
        public static readonly AppError ProductPriceIsInvalidFormat =       AppErrorFactory.CreateInvalidFormat($"OBJECT.PRODUCT_PRICE",    3_04_03);
        public static readonly AppError ProductPriceIsInvalidTooLarge =     AppErrorFactory.CreateTooLarge($"OBJECT.PRODUCT_PRICE",         3_04_03);
        public static readonly AppError ProductPriceIsInvalidTooSmall =     AppErrorFactory.CreateTooSmall($"OBJECT.PRODUCT_PRICE",         3_04_03);
    }
}
