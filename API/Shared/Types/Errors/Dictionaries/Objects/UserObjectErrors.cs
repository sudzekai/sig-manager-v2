using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности User
    /// 
    /// <para>Сущность ошибок - 12</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - USER_USERNAME</br>
    /// <br>03 - USER_EMAIL</br>
    /// <br>04 - USER_PASSWORD</br>
    /// <br>05 - FullName</br>
    /// <br>06 - PhoneNumber</br>
    /// <br>07 - VerificationCode</br>
    /// </para>
    /// </summary>
    public static class UserObjectErrors
    {
        /// <summary>
        /// Инициализация для проверки уникальности ключей и кодов ошибок
        /// </summary>
        public static void Initialize()
        {
            _ = UserIdIsToSmall;

            _ = UsernameIsRequired;
            _ = UsernameIsInvalid;
            _ = UsernameIsInvalidLength;
            _ = UsernameIsInvalidFormat;
            _ = UsernameIsInvalidTooLarge;
            _ = UsernameIsInvalidTooSmall;

            _ = EmailIsRequired;
            _ = EmailIsInvalid;
            _ = EmailIsInvalidLength;
            _ = EmailIsInvalidFormat;
            _ = EmailIsInvalidTooLarge;
            _ = EmailIsInvalidTooSmall;

            _ = PasswordIsRequired;
            _ = PasswordIsInvalid;
            _ = PasswordIsInvalidLength;
            _ = PasswordIsInvalidFormat;
            _ = PasswordIsInvalidTooLarge;
            _ = PasswordIsInvalidTooSmall;

            _ = FullNameIsRequired;
            _ = FullNameIsInvalid;
            _ = FullNameIsInvalidLength;
            _ = FullNameIsInvalidFormat;
            _ = FullNameIsInvalidTooLarge;
            _ = FullNameIsInvalidTooSmall;

            _ = PhoneNumberIsRequired;
            _ = PhoneNumberIsInvalid;
            _ = PhoneNumberIsInvalidLength;
            _ = PhoneNumberIsInvalidFormat;
            _ = PhoneNumberIsInvalidTooLarge;
            _ = PhoneNumberIsInvalidTooSmall;

            _ = VerificationCodeIsRequired;
            _ = VerificationCodeIsInvalid;
            _ = VerificationCodeIsInvalidLength;
            _ = VerificationCodeIsInvalidFormat;
            _ = VerificationCodeIsInvalidTooLarge;
            _ = VerificationCodeIsInvalidTooSmall;
        }

        // id = 1
        public static readonly AppError UserIdIsToSmall =                   AppErrorFactory.CreateTooSmall($"OBJECT.USER_ID",               3_12_01);

        // user_username = 2
        public static readonly AppError UsernameIsRequired =                AppErrorFactory.CreateRequired($"OBJECT.USER_USERNAME",              3_12_02);
        public static readonly AppError UsernameIsInvalid =                 AppErrorFactory.CreateInvalid($"OBJECT.USER_USERNAME",               3_12_02);
        public static readonly AppError UsernameIsInvalidLength =           AppErrorFactory.CreateInvalidLength($"OBJECT.USER_USERNAME",         3_12_02);
        public static readonly AppError UsernameIsInvalidFormat =           AppErrorFactory.CreateInvalidFormat($"OBJECT.USER_USERNAME",         3_12_02);
        public static readonly AppError UsernameIsInvalidTooLarge =         AppErrorFactory.CreateTooLarge($"OBJECT.USER_USERNAME",              3_12_02);
        public static readonly AppError UsernameIsInvalidTooSmall =         AppErrorFactory.CreateTooSmall($"OBJECT.USER_USERNAME",              3_12_02);

        // user_email = 3
        public static readonly AppError EmailIsRequired =                   AppErrorFactory.CreateRequired("OBJECT.USER_EMAIL",                  3_12_03);
        public static readonly AppError EmailIsInvalid =                    AppErrorFactory.CreateInvalid("OBJECT.USER_EMAIL",                   3_12_03);
        public static readonly AppError EmailIsInvalidLength =              AppErrorFactory.CreateInvalidLength("OBJECT.USER_EMAIL",             3_12_03);
        public static readonly AppError EmailIsInvalidFormat =              AppErrorFactory.CreateInvalidFormat("OBJECT.USER_EMAIL",             3_12_03);
        public static readonly AppError EmailIsInvalidTooLarge =            AppErrorFactory.CreateTooLarge("OBJECT.USER_EMAIL",                  3_12_03);
        public static readonly AppError EmailIsInvalidTooSmall =            AppErrorFactory.CreateTooSmall("OBJECT.USER_EMAIL",                  3_12_03);

        // user_password = 4
        public static readonly AppError PasswordIsRequired =                AppErrorFactory.CreateRequired("OBJECT.USER_PASSWORD",               3_12_04);
        public static readonly AppError PasswordIsInvalid =                 AppErrorFactory.CreateInvalid("OBJECT.USER_PASSWORD",                3_12_04);
        public static readonly AppError PasswordIsInvalidLength =           AppErrorFactory.CreateInvalidLength("OBJECT.USER_PASSWORD",          3_12_04);
        public static readonly AppError PasswordIsInvalidFormat =           AppErrorFactory.CreateInvalidFormat("OBJECT.USER_PASSWORD",          3_12_04);
        public static readonly AppError PasswordIsInvalidTooLarge =         AppErrorFactory.CreateTooLarge("OBJECT.USER_PASSWORD",               3_12_04);
        public static readonly AppError PasswordIsInvalidTooSmall =         AppErrorFactory.CreateTooSmall("OBJECT.USER_PASSWORD",               3_12_04);

        // uSER_FULL_NAME = 5
        public static readonly AppError FullNameIsRequired =                AppErrorFactory.CreateRequired("OBJECT.USER_FULL_NAME",              3_12_05);
        public static readonly AppError FullNameIsInvalid =                 AppErrorFactory.CreateInvalid("OBJECT.USER_FULL_NAME",               3_12_05);
        public static readonly AppError FullNameIsInvalidLength =           AppErrorFactory.CreateInvalidLength("OBJECT.USER_FULL_NAME",         3_12_05);
        public static readonly AppError FullNameIsInvalidFormat =           AppErrorFactory.CreateInvalidFormat("OBJECT.USER_FULL_NAME",         3_12_05);
        public static readonly AppError FullNameIsInvalidTooLarge =         AppErrorFactory.CreateTooLarge("OBJECT.USER_FULL_NAME",              3_12_05);
        public static readonly AppError FullNameIsInvalidTooSmall =         AppErrorFactory.CreateTooSmall("OBJECT.USER_FULL_NAME",              3_12_05);

        // uSER_PHONE_NUMBER = 6
        public static readonly AppError PhoneNumberIsRequired =             AppErrorFactory.CreateRequired("OBJECT.USER_PHONE_NUMBER",           3_12_06);
        public static readonly AppError PhoneNumberIsInvalid =              AppErrorFactory.CreateInvalid("OBJECT.USER_PHONE_NUMBER",            3_12_06);
        public static readonly AppError PhoneNumberIsInvalidLength =        AppErrorFactory.CreateInvalidLength("OBJECT.USER_PHONE_NUMBER",      3_12_06);
        public static readonly AppError PhoneNumberIsInvalidFormat =        AppErrorFactory.CreateInvalidFormat("OBJECT.USER_PHONE_NUMBER",      3_12_06);
        public static readonly AppError PhoneNumberIsInvalidTooLarge =      AppErrorFactory.CreateTooLarge("OBJECT.USER_PHONE_NUMBER",           3_12_06);
        public static readonly AppError PhoneNumberIsInvalidTooSmall =      AppErrorFactory.CreateTooSmall("OBJECT.USER_PHONE_NUMBER",           3_12_06);

        // uSER_VERIFICATION_CODE = 7
        public static readonly AppError VerificationCodeIsRequired =        AppErrorFactory.CreateRequired("OBJECT.USER_VERIFICATION_CODE",      3_12_07);
        public static readonly AppError VerificationCodeIsInvalid =         AppErrorFactory.CreateInvalid("OBJECT.USER_VERIFICATION_CODE",       3_12_07);
        public static readonly AppError VerificationCodeIsInvalidLength =   AppErrorFactory.CreateInvalidLength("OBJECT.USER_VERIFICATION_CODE", 3_12_07);
        public static readonly AppError VerificationCodeIsInvalidFormat =   AppErrorFactory.CreateInvalidFormat("OBJECT.USER_VERIFICATION_CODE", 3_12_07);
        public static readonly AppError VerificationCodeIsInvalidTooLarge = AppErrorFactory.CreateTooLarge("OBJECT.USER_VERIFICATION_CODE",      3_12_07);
        public static readonly AppError VerificationCodeIsInvalidTooSmall = AppErrorFactory.CreateTooSmall("OBJECT.USER_VERIFICATION_CODE",      3_12_07);
    }
}
