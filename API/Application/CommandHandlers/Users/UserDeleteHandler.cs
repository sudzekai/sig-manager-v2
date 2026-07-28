using Application.Commands.Users;
using Application.Objects;
using Domain.ValueObjects.Users;
using Infrastructure.Repositories.Users;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Users
{
    internal class UserDeleteHandler(IUserRepository repo) : ICommandHandler<UserDeleteCommand, Unit>
    {
        public async Task<Unit> HandleAsync(UserDeleteCommand command)
        {
            (await repo.DeleteAsync(UserId.FromValue(command.Id)))
                .ThrowIfFalse(EntityErrors.UserNotFound);
                    
            return Unit.Value;
        }
    }
}
