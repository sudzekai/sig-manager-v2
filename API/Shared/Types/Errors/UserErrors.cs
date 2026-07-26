namespace Shared.Types.Errors
{
    public static class UserErrors
    {
        // default = 0
        public static readonly ErrorCode NotFound =                         ErrorCode.Create($"USER.NOT_FOUND",                        1_00_00);

        // id = 1
        public static readonly ErrorCode IdIsInvalid =                      ErrorCode.Create($"USER.ID.INVALID",                       1_01_01);

        // role_id = 2
        public static readonly ErrorCode RoleIdIsRequired =                 ErrorCode.Create($"USER.ROLE_ID.REQUIRED",                 1_02_01);
        public static readonly ErrorCode RoleIdIsInvalid =                  ErrorCode.Create($"USER.ROLE_ID.INVALID",                  1_02_02);
        public static readonly ErrorCode UserPhoneNumberAlreadyExists =     ErrorCode.Create($"USER.PHONE_NUMBER.CONFLICT",            1_02_03);

        // username = 3
        public static readonly ErrorCode UsernameIsRequired =               ErrorCode.Create($"USER.USERNAME.REQUIRED",                1_03_01);
        public static readonly ErrorCode UsernameIsInvalid =                ErrorCode.Create($"USER.USERNAME.INVALID",                 1_03_02);
        public static readonly ErrorCode UsernameIsInvalidLength =          ErrorCode.Create($"USER.USERNAME.INVALID_LENGTH",          1_03_03);
        public static readonly ErrorCode UsernameAlreadyExists =            ErrorCode.Create($"USER.USERNAME.CONFLICT",                1_03_04);

        // email = 4
        public static readonly ErrorCode EmailIsRequired =                  ErrorCode.Create($"USER.EMAIL.REQUIRED",                   1_04_01);
        public static readonly ErrorCode EmailIsInvalid =                   ErrorCode.Create($"USER.EMAIL.INVALID",                    1_04_02);
        public static readonly ErrorCode EmailIsInvalidFormat =             ErrorCode.Create($"USER.EMAIL.INVALID_FORMAT",             1_04_03);
        public static readonly ErrorCode EmailIsInvalidLength =             ErrorCode.Create($"USER.EMAIL.INVALID_LENGTH",             1_04_04);
        public static readonly ErrorCode EmailAlreadyExists =               ErrorCode.Create($"USER.EMAIL.CONFLICT",                   1_04_05);

        // password = 5
        public static readonly ErrorCode PasswordIsRequired =               ErrorCode.Create($"USER.PASSWORD.REQUIRED",                1_05_01);
        public static readonly ErrorCode PasswordIsInvalid =                ErrorCode.Create($"USER.PASSWORD.INVALID",                 1_05_02);

        // full_name = 6
        public static readonly ErrorCode FullNameIsRequired =               ErrorCode.Create($"USER.FULL_NAME.REQUIRED",               1_06_01);
        public static readonly ErrorCode FullNameIsInvalidLength =          ErrorCode.Create($"USER.FULL_NAME.INVALID_LENGTH",         1_06_02);
        public static readonly ErrorCode FullNameIsInvalid =                ErrorCode.Create($"USER.FULL_NAME.INVALID",                1_06_03);

        // phone_number = 7
        public static readonly ErrorCode PhoneNumberIsRequired =            ErrorCode.Create($"USER.PHONE_NUMBER.REQUIRED",            1_07_01);
        public static readonly ErrorCode PhoneNumberIsInvalid =             ErrorCode.Create($"USER.PHONE_NUMBER.INVALID",             1_07_02);
        public static readonly ErrorCode PhoneNumberIsInvalidFormat =       ErrorCode.Create($"USER.PHONE_NUMBER.INVALID_FORMAT",      1_07_03);
        public static readonly ErrorCode PhoneNumberIsInvalidLength =       ErrorCode.Create($"USER.PHONE_NUMBER.INVALID_LENGTH",      1_07_04);
        public static readonly ErrorCode PhoneNumberAlreadyExists =         ErrorCode.Create($"USER.PHONE_NUMBER.CONFLICT",            1_07_05);

        // verification_code = 8
        public static readonly ErrorCode VerificationCodeIsRequired =       ErrorCode.Create($"USER.VERIFICATION_CODE.REQUIRED",       1_08_01);
        public static readonly ErrorCode VerificationCodeIsInvalid =        ErrorCode.Create($"USER.VERIFICATION_CODE.INVALID",        1_08_02);
        public static readonly ErrorCode VerificationCodeIsInvalidLength =  ErrorCode.Create($"USER.VERIFICATION_CODE.INVALID_LENGTH", 1_08_03);
    }
}
