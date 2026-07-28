using Application.Commands.Users;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Infrastructure.Repositories.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Users
{
    internal class UserRoleUpdateHandler(
        IUserRepository repo,
        IUsersQuery users
    ) : ICommandHandler<UserRoleUpdateCommand, UserDto>
    {
        public async Task<UserDto> HandleAsync(UserRoleUpdateCommand command)
        {
            var user = (await repo.GetAsync(UserId.FromValue(command.Id)))
                .OrThrowIfNull(EntityErrors.UserNotFound);

            var dto = command.Dto;

            user.ChangeRoleId(dto.RoleId);

            await repo.UpdateAsync(user);

            return (await users.GetByIdAsync(user.Id))
                .OrThrowIfNull(EntityErrors.UserNotFound);
        }
    }
}
