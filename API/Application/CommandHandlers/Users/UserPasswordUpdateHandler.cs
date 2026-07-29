using Application.Commands.Users;
using Application.Objects;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Infrastructure.Repositories.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Users
{
    internal class UserPasswordUpdateHandler(
        IUserRepository repo
    ) : ICommandHandler<UserPasswordUpdateCommand, Unit>
    {
        public async Task<Unit> HandleAsync(UserPasswordUpdateCommand command)
        {
            var user = (await repo.GetAsync(UserId.FromValue(command.Id)))
                .OrThrowIfNull(EntityErrors.UserNotFound);

            var dto = command.Dto;

            user.ChangePasswordHash(PasswordHash.FromValue(dto.password));

            await repo.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
