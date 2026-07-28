using Application.Commands.Roles;
using Application.Objects;
using Domain.ValueObjects.Roles;
using Infrastructure.Repositories.Roles;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Roles
{
    public class RoleDeleteHandler(IRoleRepository repo) : ICommandHandler<RoleDeleteCommand, Unit>
    {
        public async Task<Unit> HandleAsync(RoleDeleteCommand command)
        {
            (await repo.DeleteAsync(RoleId.FromValue(command.Id)))
                .ThrowIfFalse(EntityErrors.RoleNotFound);

            return Unit.Value;
        }
    }
}
