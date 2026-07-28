using Application.Commands.Positions;
using Application.Objects;
using Domain.ValueObjects.Positions;
using Infrastructure.Repositories.Positions;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Positions
{
    public class PositionDeleteHandler(IPositionRepository repo) : ICommandHandler<PositionDeleteCommand, Unit>
    {
        public async Task<Unit> HandleAsync(PositionDeleteCommand command)
        {
            (await repo.DeleteAsync(PositionId.FromValue(command.Id)))
                .ThrowIfFalse(EntityErrors.PositionNotFound);

            return Unit.Value;
        }
    }
}
