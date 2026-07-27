using Shared.Types.Errors.ApplicationError;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;
using System.Net;

namespace Shared.Utilities.BusinessErrorFactory.Handlers.Objects;

public static class UserObjectErrorsHandler
{
    private static readonly Dictionary<AppError, BusinessException> _errors = new()
    {
        { UserObjectErrors.UserIdIsToSmall, new("Идентификатор пользователя должен быть больше допустимого значения", (int)HttpStatusCode.BadRequest) },

        { UserObjectErrors.UsernameIsRequired, new("Имя пользователя не может быть пустым", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.UsernameIsInvalid, new("Имя пользователя содержит недопустимые символы", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.UsernameIsInvalidLength, new("Длина имени пользователя недопустима", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.UsernameIsInvalidFormat, new("Некорректный формат имени пользователя", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.UsernameIsInvalidTooLarge, new("Имя пользователя превышает максимально допустимую длину", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.UsernameIsInvalidTooSmall, new("Имя пользователя меньше минимально допустимой длины", (int)HttpStatusCode.BadRequest) },

        { UserObjectErrors.EmailIsRequired, new("Электронная почта не может быть пустой", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.EmailIsInvalid, new("Некорректное значение электронной почты", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.EmailIsInvalidLength, new("Длина электронной почты недопустима", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.EmailIsInvalidFormat, new("Некорректный формат электронной почты", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.EmailIsInvalidTooLarge, new("Электронная почта превышает максимально допустимую длину", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.EmailIsInvalidTooSmall, new("Электронная почта меньше минимально допустимой длины", (int)HttpStatusCode.BadRequest) },

        { UserObjectErrors.PasswordIsRequired, new("Пароль не может быть пустым", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PasswordIsInvalid, new("Пароль не соответствует требованиям", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PasswordIsInvalidLength, new("Длина пароля недопустима", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PasswordIsInvalidFormat, new("Некорректный формат пароля", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PasswordIsInvalidTooLarge, new("Пароль превышает максимально допустимую длину", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PasswordIsInvalidTooSmall, new("Пароль меньше минимально допустимой длины", (int)HttpStatusCode.BadRequest) },

        { UserObjectErrors.FullNameIsRequired, new("ФИО не может быть пустым", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.FullNameIsInvalid, new("Некорректное ФИО", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.FullNameIsInvalidLength, new("Длина ФИО недопустима", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.FullNameIsInvalidFormat, new("Некорректный формат ФИО", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.FullNameIsInvalidTooLarge, new("ФИО превышает максимально допустимую длину", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.FullNameIsInvalidTooSmall, new("ФИО меньше минимально допустимой длины", (int)HttpStatusCode.BadRequest) },

        { UserObjectErrors.PhoneNumberIsRequired, new("Номер телефона не может быть пустым", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PhoneNumberIsInvalid, new("Некорректный номер телефона", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PhoneNumberIsInvalidLength, new("Длина номера телефона недопустима", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PhoneNumberIsInvalidFormat, new("Некорректный формат номера телефона", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PhoneNumberIsInvalidTooLarge, new("Номер телефона превышает максимально допустимую длину", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.PhoneNumberIsInvalidTooSmall, new("Номер телефона меньше минимально допустимой длины", (int)HttpStatusCode.BadRequest) },

        { UserObjectErrors.VerificationCodeIsRequired, new("Код подтверждения не может быть пустым", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.VerificationCodeIsInvalid, new("Некорректный код подтверждения", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.VerificationCodeIsInvalidLength, new("Длина кода подтверждения недопустима", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.VerificationCodeIsInvalidFormat, new("Некорректный формат кода подтверждения", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.VerificationCodeIsInvalidTooLarge, new("Код подтверждения превышает максимально допустимую длину", (int)HttpStatusCode.BadRequest) },
        { UserObjectErrors.VerificationCodeIsInvalidTooSmall, new("Код подтверждения меньше минимально допустимой длины", (int)HttpStatusCode.BadRequest) }
    };

    public static BusinessException Handle(AppException ex)
        => _errors.GetValueOrDefault(ex.Error)
        ?? BusinessException.Unknown(ex.Error.Code);
}