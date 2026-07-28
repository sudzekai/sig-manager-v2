using Application.Commands.Parks;
using Application.Objects;
using Domain.ValueObjects.Parks;
using Infrastructure.Repositories.Parks;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Parks
{
    public class ParkDeleteHandler(IParkRepository repo) : ICommandHandler<ParkDeleteCommand, Unit>
    {
        public async Task<Unit> HandleAsync(ParkDeleteCommand command)
        {
            (await repo.DeleteAsync(ParkId.FromValue(command.Id)))
                .ThrowIfFalse(EntityErrors.ParkNotFound);

            return Unit.Value;
        }
    }
}
