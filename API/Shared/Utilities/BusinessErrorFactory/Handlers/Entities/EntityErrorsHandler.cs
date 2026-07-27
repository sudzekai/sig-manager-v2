using Shared.Types.Errors.ApplicationError;
using Shared.Types.Errors.Dictionaries.Entities;
using Shared.Types.Exceptions;
using System.Net;

namespace Shared.Utilities.BusinessErrorFactory.Handlers.Entities
{
    public static class EntityErrorsHandler
    {
        private static readonly Dictionary<AppError, BusinessException> _errors = new()
        {
            { EntityErrors.UserNotFound, new("Пользователь не найден", (int)HttpStatusCode.NotFound) },
            { EntityErrors.UserUsernameAlreadyExists, new("Пользователь с таким именем уже существует", (int)HttpStatusCode.Conflict) },
            { EntityErrors.UserEmailAlreadyExists, new("Пользователь с такой электронной почтой уже существует", (int)HttpStatusCode.Conflict) },
            { EntityErrors.UserPhoneNumberAlreadyExists, new("Пользователь с таким номером телефона уже существует", (int)HttpStatusCode.Conflict) },

            { EntityErrors.RoleNotFound, new("Роль не найдена", (int)HttpStatusCode.NotFound) },
            { EntityErrors.CarNotFound, new("Машинка не найдена", (int)HttpStatusCode.NotFound) },
            { EntityErrors.ParkNotFound, new("Парк не найден", (int)HttpStatusCode.NotFound) },
            { EntityErrors.PositionNotFound, new("Должность не найдена", (int)HttpStatusCode.NotFound) },
            { EntityErrors.ProductNotFound, new("Товар не найден", (int)HttpStatusCode.NotFound) },
            { EntityErrors.RightNotFound, new("Право не найдено", (int)HttpStatusCode.NotFound) },
            { EntityErrors.CarShiftNotFound, new("Смена машинок не найдена", (int)HttpStatusCode.NotFound) },
            { EntityErrors.PopcornShiftNotFound, new("Смена ваты не найдена", (int)HttpStatusCode.NotFound) },
            { EntityErrors.BouncerShiftNotFound, new("Смена батута не найдена", (int)HttpStatusCode.NotFound) },
            { EntityErrors.TrainShiftNotFound, new("Смена паровоза не найдена", (int)HttpStatusCode.NotFound) },
            { EntityErrors.CarouselShiftNotFound, new("Смена карусели не найдена", (int)HttpStatusCode.NotFound) }

        };

        public static BusinessException Handle(AppException ex)
            => _errors.GetValueOrDefault(ex.ErrorCode)
            ?? BusinessException.Unknown(ex.ErrorCode.Code);
    }
}