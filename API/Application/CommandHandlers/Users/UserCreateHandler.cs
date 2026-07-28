using Application.Commands.Users;
using Domain.Models.Users;
using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Infrastructure.Repositories.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Users
{
    internal class UserCreateHandler(
        IUserRepository repo,
        IUsersQuery users
    ) : ICommandHandler<UserCreateCommand, UserDto>
    {
        public async Task<UserDto> HandleAsync(UserCreateCommand command)
        {
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

            var createdId = await repo.AddAsync(User.Create(
                username,
                FullName.FromValue(dto.FullName),
                email,
                phoneNumber,
                PasswordHash.FromValue(dto.Password),
                RoleId.FromValue(1)
            ));

            return (await users.GetByIdAsync(createdId))
                .OrThrowIfNull(EntityErrors.UserNotFound);
        }
    }
}
