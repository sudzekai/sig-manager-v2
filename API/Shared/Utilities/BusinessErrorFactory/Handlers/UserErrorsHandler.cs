using Shared.Types.Errors;
using Shared.Types.Exceptions;
using System.Net;

namespace Shared.Utilities.BusinessErrorFactory.Handlers
{
    public static class UserErrorsHandler
    {
        public static BusinessException Handle(AppException ex)
        {
            var err = ex.ErrorCode;

            if (err == UserErrors.NotFound)
                return new("Такой пользователь не найден", (int)HttpStatusCode.NotFound);

            if (err == UserErrors.IdIsInvalid)
                return new("Некорректный идентификатор пользователя", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.RoleIdIsRequired)
                return new("Необходимо указать роль пользователя", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.RoleIdIsInvalid)
                return new("Указана некорректная роль пользователя", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.UserPhoneNumberAlreadyExists)
                return new("Пользователь с таким номером телефона уже существует", (int)HttpStatusCode.Conflict);

            if (err == UserErrors.UsernameIsRequired)
                return new("Имя пользователя не может быть пустым", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.UsernameIsInvalid)
                return new("Имя пользователя содержит недопустимые символы", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.UsernameIsInvalidLength)
                return new("Длина имени пользователя недопустима", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.UsernameAlreadyExists)
                return new("Пользователь с таким именем уже существует", (int)HttpStatusCode.Conflict);

            if (err == UserErrors.EmailIsRequired)
                return new("Электронная почта не может быть пустой", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.EmailIsInvalid)
                return new("Некорректное значение электронной почты", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.EmailIsInvalidFormat)
                return new("Некорректный формат электронной почты", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.EmailIsInvalidLength)
                return new("Длина электронной почты недопустима", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.EmailAlreadyExists)
                return new("Пользователь с такой электронной почтой уже существует", (int)HttpStatusCode.Conflict);

            if (err == UserErrors.PasswordIsRequired)
                return new("Пароль не может быть пустым", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.PasswordIsInvalid)
                return new("Пароль не соответствует требованиям", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.FullNameIsRequired)
                return new("ФИО не может быть пустым", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.FullNameIsInvalidLength)
                return new("Длина ФИО недопустима", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.FullNameIsInvalid)
                return new("Некорректное ФИО", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.PhoneNumberIsRequired)
                return new("Номер телефона не может быть пустым", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.PhoneNumberIsInvalid)
                return new("Некорректный номер телефона", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.PhoneNumberIsInvalidFormat)
                return new("Некорректный формат номера телефона", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.PhoneNumberIsInvalidLength)
                return new("Длина номера телефона недопустима", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.PhoneNumberAlreadyExists)
                return new("Пользователь с таким номером телефона уже существует", (int)HttpStatusCode.Conflict);

            if (err == UserErrors.VerificationCodeIsRequired)
                return new("Код подтверждения не может быть пустым", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.VerificationCodeIsInvalid)
                return new("Некорректный код подтверждения", (int)HttpStatusCode.BadRequest);

            if (err == UserErrors.VerificationCodeIsInvalidLength)
                return new("Длина кода подтверждения недопустима", (int)HttpStatusCode.BadRequest);

            return BusinessException.Unknown;
        }
    }
}
