using Application.Commands.Users;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Infrastructure.Repositories.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.Dictionaries.Entities;
using Shared.Types.Exceptions;

namespace Application.CommandHandlers.Users
{
    internal class UserRoleUpdateHandler(
        IUserRepository repo,
        IUsersQuery users
    ) : ICommandHandler<UserRoleUpdateCommand, UserDto>
    {
        public async Task<UserDto> HandleAsync(UserRoleUpdateCommand command)
        {
            var user = await repo.GetAsync(UserId.FromValue(command.Id))
                ?? throw new AppException(EntityErrors.UserNotFound);

            var dto = command.Dto;

            user.ChangeRoleId(dto.RoleId);

            await repo.UpdateAsync(user);

            return await users.GetByIdAsync(user.Id)
                ?? throw new AppException(EntityErrors.UserNotFound); ;
        }
    }
}
