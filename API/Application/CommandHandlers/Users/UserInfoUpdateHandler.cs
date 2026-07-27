using Application.Commands.Users;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Infrastructure.Repositories.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.Dictionaries.Entities;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Application.CommandHandlers.Users
{
    internal class UserInfoUpdateHandler(
        IUserRepository repo,
        IUsersQuery users
    ) : ICommandHandler<UserInfoUpdateCommand, UserDto>
    {
        public async Task<UserDto> HandleAsync(UserInfoUpdateCommand command)
        {
            var user = await repo.GetAsync(UserId.FromValue(command.Id))
                ?? throw new AppException(EntityErrors.UserNotFound);

            var dto = command.Dto;

            var username = Username.FromValue(dto.Username);

            if (await repo.GetByUsernameAsync(username) is not null)
                throw new AppException(EntityErrors.UserUsernameAlreadyExists);

            var email = Email.FromValue(dto.Email);

            if (await repo.GetByEmailAsync(email) is not null)
                throw new AppException(EntityErrors.UserEmailAlreadyExists);

            var phoneNumber = PhoneNumber.FromValue(dto.PhoneNumber);

            if (await repo.GetByPhoneNumberAsync(phoneNumber) is not null)
                throw new AppException(EntityErrors.UserPhoneNumberAlreadyExists);

            user.ChangeUsername(username);
            user.ChangeEmail(email);
            user.ChangePhoneNumber(phoneNumber);
            user.ChangeFullName(FullName.FromValue(dto.FullName));

            await repo.UpdateAsync(user);

            return await users.GetByIdAsync(user.Id)
                ?? throw new AppException(EntityErrors.UserNotFound);
        }
    }
}
