using Application.Commands.Cars;
using Application.Objects;
using Domain.ValueObjects.Cars;
using Infrastructure.Repositories.Cars;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Cars
{
    public class CarDeleteHandler(ICarRepository repo) : ICommandHandler<CarDeleteCommand, Unit>
    {
        public async Task<Unit> HandleAsync(CarDeleteCommand command)
        {
            (await repo.DeleteAsync(CarId.FromValue(command.Id)))
                .ThrowIfFalse(EntityErrors.CarNotFound);

            return Unit.Value;
        }
    }
}
