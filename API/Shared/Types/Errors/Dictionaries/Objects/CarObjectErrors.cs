using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности Car
    /// 
    /// <para>Сущность ошибок - 01</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - Name</br>
    /// <br>03 - Status</br>
    /// <br>04 - ControllerModel</br>
    /// </summary>
    public class CarObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = CarIdIsToSmall;

            _ = CarNameIsRequired;
            _ = CarNameIsInvalid;
            _ = CarNameIsInvalidLength;
            _ = CarNameIsInvalidFormat;
            _ = CarNameIsInvalidTooLarge;
            _ = CarNameIsInvalidTooSmall;

            _ = CarStatusIsRequired;
            _ = CarStatusIsInvalid;
        }

        // carid = 1
        public static readonly AppError CarIdIsToSmall =                        AppErrorFactory.CreateTooSmall($"OBJECT.CAR_ID",                    3_01_01);

        // carname = 2
        public static readonly AppError CarNameIsRequired =                     AppErrorFactory.CreateRequired($"OBJECT.CAR_NAME",                  3_01_02);
        public static readonly AppError CarNameIsInvalid =                      AppErrorFactory.CreateInvalid($"OBJECT.CAR_NAME",                   3_01_02);
        public static readonly AppError CarNameIsInvalidLength =                AppErrorFactory.CreateInvalidLength($"OBJECT.CAR_NAME",             3_01_02);
        public static readonly AppError CarNameIsInvalidFormat =                AppErrorFactory.CreateInvalidFormat($"OBJECT.CAR_NAME",             3_01_02);
        public static readonly AppError CarNameIsInvalidTooLarge =              AppErrorFactory.CreateTooLarge($"OBJECT.CAR_NAME",                  3_01_02);
        public static readonly AppError CarNameIsInvalidTooSmall =              AppErrorFactory.CreateTooSmall($"OBJECT.CAR_NAME",                  3_01_02);

        // carstatus = 3
        public static readonly AppError CarStatusIsRequired =                   AppErrorFactory.CreateRequired($"OBJECT.CAR_STATUS",                3_01_03);
        public static readonly AppError CarStatusIsInvalid =                    AppErrorFactory.CreateInvalid($"OBJECT.CAR_STATUS",                 3_01_03);

        // carcontrollermodel = 4
        public static readonly AppError CarControllerModelIsRequired =          AppErrorFactory.CreateRequired($"OBJECT.CAR_CONTROLLER_MODEL",      3_01_04);
        public static readonly AppError CarControllerModelIsInvalid =           AppErrorFactory.CreateInvalid($"OBJECT.CAR_CONTROLLER_MODEL",       3_01_04);
        public static readonly AppError CarControllerModelIsInvalidLength =     AppErrorFactory.CreateInvalidLength($"OBJECT.CAR_CONTROLLER_MODEL", 3_01_04);
        public static readonly AppError CarControllerModelIsInvalidFormat =     AppErrorFactory.CreateInvalidFormat($"OBJECT.CAR_CONTROLLER_MODEL", 3_01_04);
        public static readonly AppError CarControllerModelIsInvalidTooLarge =   AppErrorFactory.CreateTooLarge($"OBJECT.CAR_CONTROLLER_MODEL",      3_01_04);
        public static readonly AppError CarControllerModelIsInvalidTooSmall =   AppErrorFactory.CreateTooSmall($"OBJECT.CAR_CONTROLLER_MODEL",      3_01_04);
    }
}
