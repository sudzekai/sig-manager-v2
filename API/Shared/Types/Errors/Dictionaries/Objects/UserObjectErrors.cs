using Shared.Types.Errors.ApplicationError;

namespace Shared.Types.Errors.Dictionaries.Objects
{
    /// <summary>
    /// Определяет ошибки для объектов доменной сущности User
    /// 
    /// <para>Префикс ошибок - 1</para>
    /// 
    /// <para>Тела ошибок:
    /// <br>01 - Id</br>
    /// <br>02 - Username</br>
    /// <br>03 - Email</br>
    /// <br>04 - Password</br>
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
        public static readonly AppError UserIdIsToSmall =                   AppErrorFactory.CreateTooSmall($"OBJECT.USER_ID",               3_01_01);

        // username = 2
        public static readonly AppError UsernameIsRequired =                AppErrorFactory.CreateRequired($"OBJECT.USERNAME",              3_01_02);
        public static readonly AppError UsernameIsInvalid =                 AppErrorFactory.CreateInvalid($"OBJECT.USERNAME",               3_01_02);
        public static readonly AppError UsernameIsInvalidLength =           AppErrorFactory.CreateInvalidLength($"OBJECT.USERNAME",         3_01_02);
        public static readonly AppError UsernameIsInvalidFormat =           AppErrorFactory.CreateInvalidFormat($"OBJECT.USERNAME",         3_01_02);
        public static readonly AppError UsernameIsInvalidTooLarge =         AppErrorFactory.CreateTooLarge($"OBJECT.USERNAME",              3_01_02);
        public static readonly AppError UsernameIsInvalidTooSmall =         AppErrorFactory.CreateTooSmall($"OBJECT.USERNAME",              3_01_02);

        // email = 3
        public static readonly AppError EmailIsRequired =                   AppErrorFactory.CreateRequired("OBJECT.EMAIL",                  3_01_03);
        public static readonly AppError EmailIsInvalid =                    AppErrorFactory.CreateInvalid("OBJECT.EMAIL",                   3_01_03);
        public static readonly AppError EmailIsInvalidLength =              AppErrorFactory.CreateInvalidLength("OBJECT.EMAIL",             3_01_03);
        public static readonly AppError EmailIsInvalidFormat =              AppErrorFactory.CreateInvalidFormat("OBJECT.EMAIL",             3_01_03);
        public static readonly AppError EmailIsInvalidTooLarge =            AppErrorFactory.CreateTooLarge("OBJECT.EMAIL",                  3_01_03);
        public static readonly AppError EmailIsInvalidTooSmall =            AppErrorFactory.CreateTooSmall("OBJECT.EMAIL",                  3_01_03);

        // password = 4
        public static readonly AppError PasswordIsRequired =                AppErrorFactory.CreateRequired("OBJECT.PASSWORD",               3_01_04);
        public static readonly AppError PasswordIsInvalid =                 AppErrorFactory.CreateInvalid("OBJECT.PASSWORD",                3_01_04);
        public static readonly AppError PasswordIsInvalidLength =           AppErrorFactory.CreateInvalidLength("OBJECT.PASSWORD",          3_01_04);
        public static readonly AppError PasswordIsInvalidFormat =           AppErrorFactory.CreateInvalidFormat("OBJECT.PASSWORD",          3_01_04);
        public static readonly AppError PasswordIsInvalidTooLarge =         AppErrorFactory.CreateTooLarge("OBJECT.PASSWORD",               3_01_04);
        public static readonly AppError PasswordIsInvalidTooSmall =         AppErrorFactory.CreateTooSmall("OBJECT.PASSWORD",               3_01_04);

        // full_name = 5
        public static readonly AppError FullNameIsRequired =                AppErrorFactory.CreateRequired("OBJECT.FULL_NAME",              3_01_05);
        public static readonly AppError FullNameIsInvalid =                 AppErrorFactory.CreateInvalid("OBJECT.FULL_NAME",               3_01_05);
        public static readonly AppError FullNameIsInvalidLength =           AppErrorFactory.CreateInvalidLength("OBJECT.FULL_NAME",         3_01_05);
        public static readonly AppError FullNameIsInvalidFormat =           AppErrorFactory.CreateInvalidFormat("OBJECT.FULL_NAME",         3_01_05);
        public static readonly AppError FullNameIsInvalidTooLarge =         AppErrorFactory.CreateTooLarge("OBJECT.FULL_NAME",              3_01_05);
        public static readonly AppError FullNameIsInvalidTooSmall =         AppErrorFactory.CreateTooSmall("OBJECT.FULL_NAME",              3_01_05);

        // phone_number = 6
        public static readonly AppError PhoneNumberIsRequired =             AppErrorFactory.CreateRequired("OBJECT.PHONE_NUMBER",           3_01_06);
        public static readonly AppError PhoneNumberIsInvalid =              AppErrorFactory.CreateInvalid("OBJECT.PHONE_NUMBER",            3_01_06);
        public static readonly AppError PhoneNumberIsInvalidLength =        AppErrorFactory.CreateInvalidLength("OBJECT.PHONE_NUMBER",      3_01_06);
        public static readonly AppError PhoneNumberIsInvalidFormat =        AppErrorFactory.CreateInvalidFormat("OBJECT.PHONE_NUMBER",      3_01_06);
        public static readonly AppError PhoneNumberIsInvalidTooLarge =      AppErrorFactory.CreateTooLarge("OBJECT.PHONE_NUMBER",           3_01_06);
        public static readonly AppError PhoneNumberIsInvalidTooSmall =      AppErrorFactory.CreateTooSmall("OBJECT.PHONE_NUMBER",           3_01_06);

        // verification_code = 7
        public static readonly AppError VerificationCodeIsRequired =        AppErrorFactory.CreateRequired("OBJECT.VERIFICATION_CODE",      3_01_07);
        public static readonly AppError VerificationCodeIsInvalid =         AppErrorFactory.CreateInvalid("OBJECT.VERIFICATION_CODE",       3_01_07);
        public static readonly AppError VerificationCodeIsInvalidLength =   AppErrorFactory.CreateInvalidLength("OBJECT.VERIFICATION_CODE", 3_01_07);
        public static readonly AppError VerificationCodeIsInvalidFormat =   AppErrorFactory.CreateInvalidFormat("OBJECT.VERIFICATION_CODE", 3_01_07);
        public static readonly AppError VerificationCodeIsInvalidTooLarge = AppErrorFactory.CreateTooLarge("OBJECT.VERIFICATION_CODE",      3_01_07);
        public static readonly AppError VerificationCodeIsInvalidTooSmall = AppErrorFactory.CreateTooSmall("OBJECT.VERIFICATION_CODE",      3_01_07);
    }
}
