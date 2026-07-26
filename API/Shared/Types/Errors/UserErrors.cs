namespace Shared.Types.Errors
{
    public static class UserErrors
    {
        // default = 0
        public static readonly ErrorCode NotFound =                         ErrorCode.Create($"USER.NOT_FOUND",                        2_00_01);

        // id = 1
        public static readonly ErrorCode IdIsInvalid =                      ErrorCode.Create($"USER.ID.INVALID",                       2_01_01);

        // role_id = 2
        public static readonly ErrorCode RoleIdIsRequired =                 ErrorCode.Create($"USER.ROLE_ID.REQUIRED",                 2_02_01);
        public static readonly ErrorCode RoleIdIsInvalid =                  ErrorCode.Create($"USER.ROLE_ID.INVALID",                  2_02_02);
        public static readonly ErrorCode UserPhoneNumberAlreadyExists =     ErrorCode.Create($"USER.PHONE_NUMBER.CONFLICT",            2_02_03);

        // username = 3
        public static readonly ErrorCode UsernameIsRequired =               ErrorCode.Create($"USER.USERNAME.REQUIRED",                2_03_01);
        public static readonly ErrorCode UsernameIsInvalid =                ErrorCode.Create($"USER.USERNAME.INVALID",                 2_03_02);
        public static readonly ErrorCode UsernameIsInvalidLength =          ErrorCode.Create($"USER.USERNAME.INVALID_LENGTH",          2_03_03);
        public static readonly ErrorCode UsernameAlreadyExists =            ErrorCode.Create($"USER.USERNAME.CONFLICT",                2_03_04);

        // email = 4
        public static readonly ErrorCode EmailIsRequired =                  ErrorCode.Create($"USER.EMAIL.REQUIRED",                   2_04_01);
        public static readonly ErrorCode EmailIsInvalid =                   ErrorCode.Create($"USER.EMAIL.INVALID",                    2_04_02);
        public static readonly ErrorCode EmailIsInvalidFormat =             ErrorCode.Create($"USER.EMAIL.INVALID_FORMAT",             2_04_03);
        public static readonly ErrorCode EmailIsInvalidLength =             ErrorCode.Create($"USER.EMAIL.INVALID_LENGTH",             2_04_04);
        public static readonly ErrorCode EmailAlreadyExists =               ErrorCode.Create($"USER.EMAIL.CONFLICT",                   2_04_05);

        // password = 5
        public static readonly ErrorCode PasswordIsRequired =               ErrorCode.Create($"USER.PASSWORD.REQUIRED",                2_05_01);
        public static readonly ErrorCode PasswordIsInvalid =                ErrorCode.Create($"USER.PASSWORD.INVALID",                 2_05_02);

        // full_name = 6
        public static readonly ErrorCode FullNameIsRequired =               ErrorCode.Create($"USER.FULL_NAME.REQUIRED",               2_06_01);
        public static readonly ErrorCode FullNameIsInvalidLength =          ErrorCode.Create($"USER.FULL_NAME.INVALID_LENGTH",         2_06_02);
        public static readonly ErrorCode FullNameIsInvalid =                ErrorCode.Create($"USER.FULL_NAME.INVALID",                2_06_03);

        // phone_number = 7
        public static readonly ErrorCode PhoneNumberIsRequired =            ErrorCode.Create($"USER.PHONE_NUMBER.REQUIRED",            2_07_01);
        public static readonly ErrorCode PhoneNumberIsInvalid =             ErrorCode.Create($"USER.PHONE_NUMBER.INVALID",             2_07_02);
        public static readonly ErrorCode PhoneNumberIsInvalidFormat =       ErrorCode.Create($"USER.PHONE_NUMBER.INVALID_FORMAT",      2_07_03);
        public static readonly ErrorCode PhoneNumberIsInvalidLength =       ErrorCode.Create($"USER.PHONE_NUMBER.INVALID_LENGTH",      2_07_04);
        public static readonly ErrorCode PhoneNumberAlreadyExists =         ErrorCode.Create($"USER.PHONE_NUMBER.CONFLICT",            2_07_05);

        // verification_code = 8
        public static readonly ErrorCode VerificationCodeIsRequired =       ErrorCode.Create($"USER.VERIFICATION_CODE.REQUIRED",       2_08_01);
        public static readonly ErrorCode VerificationCodeIsInvalid =        ErrorCode.Create($"USER.VERIFICATION_CODE.INVALID",        2_08_02);
        public static readonly ErrorCode VerificationCodeIsInvalidLength =  ErrorCode.Create($"USER.VERIFICATION_CODE.INVALID_LENGTH", 2_08_03);
    }
}
