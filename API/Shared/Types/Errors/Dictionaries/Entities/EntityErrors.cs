using Shared.Types.Errors.ApplicationError;
using Shared.Types.Errors.Dictionaries.Objects;
using System.Net;

namespace Shared.Types.Errors.Dictionaries.Entities
{
    /// <summary>
    /// Класс-словарь с ошибками сущностей
    /// 
    /// <para>Префикс ошибок - 2</para>
    /// 
    /// </summary>
    public static class EntityErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = CarNotFound;
            _ = CarIdAlreadyExists;
            _ = CarNameAlreadyExists;

            _ = ParkNotFound;
            _ = ParkNameAlreadyExists;

            _ = PositionNotFound;
            _ = PositionNameAlreadyExists;

            _ = ProductNotFound;
            _ = ProductNameAlreadyExists;

            _ = RightNotFound;
            _ = RightCodeAlreadyExists;

            _ = RoleNotFound;
            _ = RoleNameAlreadyExists;

            _ = BouncerShiftNotFound;
            _ = CarouselShiftNotFound;
            _ = CarShiftNotFound;
            _ = PopcornShiftNotFound;
            _ = TrainShiftNotFound;

            _ = UserNotFound;
            _ = UserUsernameAlreadyExists;
            _ = UserEmailAlreadyExists;
            _ = UserPhoneNumberAlreadyExists;
        }

        public static readonly AppError CarNotFound =                   AppErrorFactory.CreateNotFound($"ENTITY.CAR",                       2_01_00);
        public static readonly AppError CarIdAlreadyExists =            AppErrorFactory.CreateAlreadyExists($"ENTITY.CAR.ID",               2_01_01);
        public static readonly AppError CarNameAlreadyExists =            AppErrorFactory.CreateAlreadyExists($"ENTITY.CAR.NAME",           2_01_02);
    
        public static readonly AppError ParkNotFound =                  AppErrorFactory.CreateNotFound($"ENTITY.PARK",                      2_02_00);
        public static readonly AppError ParkNameAlreadyExists =         AppErrorFactory.CreateAlreadyExists($"ENTITY.PARK.NAME",            2_02_02);

        public static readonly AppError PositionNotFound =              AppErrorFactory.CreateNotFound($"ENTITY.POSITION",                  2_03_00);
        public static readonly AppError PositionNameAlreadyExists =     AppErrorFactory.CreateAlreadyExists($"ENTITY.POSITION.NAME",        2_03_02);
    
        public static readonly AppError ProductNotFound =               AppErrorFactory.CreateNotFound($"ENTITY.PRODUCT",                   2_04_00);
        public static readonly AppError ProductNameAlreadyExists =      AppErrorFactory.CreateAlreadyExists($"ENTITY.PRODUCT.NAME",         2_04_02);

        public static readonly AppError RightNotFound =                 AppErrorFactory.CreateNotFound($"ENTITY.RIGHT",                     2_05_00);
        public static readonly AppError RightCodeAlreadyExists =        AppErrorFactory.CreateAlreadyExists($"ENTITY.RIGHT.CODE",           2_05_02);

        public static readonly AppError RoleNotFound =                  AppErrorFactory.CreateNotFound($"ENTITY.ROLE",                      2_06_00);
        public static readonly AppError RoleNameAlreadyExists =         AppErrorFactory.CreateAlreadyExists($"ENTITY.ROLE.NAME",            2_06_02);
        
        public static readonly AppError BouncerShiftNotFound =          AppErrorFactory.CreateNotFound($"ENTITY.BOUNCER_SHIFT",             2_07_00);
        public static readonly AppError CarouselShiftNotFound =         AppErrorFactory.CreateNotFound($"ENTITY.CAROUSEL_SHIFT",            2_08_00);
        public static readonly AppError CarShiftNotFound =              AppErrorFactory.CreateNotFound($"ENTITY.CAR_SHIFT",                 2_09_00);
        public static readonly AppError PopcornShiftNotFound =          AppErrorFactory.CreateNotFound($"ENTITY.POPCORN_SHIFT",             2_10_00);
        public static readonly AppError TrainShiftNotFound =            AppErrorFactory.CreateNotFound($"ENTITY.TRAIN_SHIFT",               2_11_00);

        public static readonly AppError UserNotFound =                  AppErrorFactory.CreateNotFound($"ENTITY.USER",                      2_12_00);
        public static readonly AppError UserUsernameAlreadyExists =     AppErrorFactory.CreateAlreadyExists($"ENTITY.USER.USERNAME",        2_12_02);
        public static readonly AppError UserEmailAlreadyExists =        AppErrorFactory.CreateAlreadyExists($"ENTITY.USER.EMAIL",           2_12_03);
        public static readonly AppError UserPhoneNumberAlreadyExists =  AppErrorFactory.CreateAlreadyExists($"ENTITY.USER.PHONE_NUMBER",    2_12_06);
    }
}
