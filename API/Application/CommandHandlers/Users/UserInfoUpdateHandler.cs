using Application.Commands.Users;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Infrastructure.Repositories.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Users
{
    internal class UserInfoUpdateHandler(
        IUserRepository repo,
        IUsersQuery users
    ) : ICommandHandler<UserInfoUpdateCommand, UserDto>
    {
        public async Task<UserDto> HandleAsync(UserInfoUpdateCommand command)
        {
            var user = (await repo.GetAsync(UserId.FromValue(command.Id)))
                .OrThrowIfNull(EntityErrors.UserNotFound);

            var dto = command.Dto;

            var username = Username.FromValue(dto.Username);
            (await repo.GetIdByUsernameAsync(username))
                .ThrowIfNotNull(EntityErrors.UserUsernameAlreadyExists);

            var email = Email.FromValue(dto.Email);
            (await repo.GetIdByEmailAsync(email))
                .ThrowIfNotNull(EntityErrors.UserEmailAlreadyExists);

            var phoneNumber = PhoneNumber.FromValue(dto.PhoneNumber);
            (await repo.GetIdByPhoneNumberAsync(phoneNumber))
                .ThrowIfNotNull(EntityErrors.UserPhoneNumberAlreadyExists);

            user.ChangeUsername(username);
            user.ChangeEmail(email);
            user.ChangePhoneNumber(phoneNumber);
            user.ChangeFullName(FullName.FromValue(dto.FullName));

            await repo.UpdateAsync(user);

            return (await users.GetByIdAsync(user.Id))
                .OrThrowIfNull(EntityErrors.UserNotFound);
        }
    }
}
