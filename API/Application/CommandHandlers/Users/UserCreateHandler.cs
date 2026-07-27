using Application.Commands.Users;
using Domain.Models.Users;
using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Infrastructure.Repositories.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.Dictionaries.Entities;
using Shared.Types.Exceptions;

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

            if (await repo.GetByUsernameAsync(username) is not null)
                throw new AppException(EntityErrors.UserUsernameAlreadyExists);

            var email = Email.FromValue(dto.Email);

            if (await repo.GetByEmailAsync(email) is not null)
                throw new AppException(EntityErrors.UserEmailAlreadyExists);

            var phoneNumber = PhoneNumber.FromValue(dto.PhoneNumber);

            if (await repo.GetByPhoneNumberAsync(phoneNumber) is not null)
                throw new AppException(EntityErrors.UserPhoneNumberAlreadyExists);

            var createdId = await repo.AddAsync(User.Create(
                username,
                FullName.FromValue(dto.FullName),
                email,
                phoneNumber,
                PasswordHash.FromValue(dto.Password),
                RoleId.FromValue(1)
            ));

            return await users.GetByIdAsync(createdId)
                ?? throw new AppException(EntityErrors.UserNotFound);
        }
    }
}
