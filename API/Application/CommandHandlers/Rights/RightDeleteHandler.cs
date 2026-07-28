using Application.Commands.Rights;
using Application.Objects;
using Domain.ValueObjects.Rights;
using Infrastructure.Repositories.Rights;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Rights
{
    public class RightDeleteHandler(IRightRepository repo) : ICommandHandler<RightDeleteCommand, Unit>
    {
        public async Task<Unit> HandleAsync(RightDeleteCommand command)
        {
            (await repo.DeleteAsync(RightId.FromValue(command.Id)))
                .ThrowIfFalse(EntityErrors.RightNotFound);

            return Unit.Value;
        }
    }
}
