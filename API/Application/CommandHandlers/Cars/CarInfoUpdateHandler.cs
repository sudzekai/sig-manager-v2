using Application.Commands.Cars;
using Domain.ValueObjects.Cars;
using Infrastructure.Queries.Cars;
using Infrastructure.Repositories.Cars;
using Shared.Dtos.Cars;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Cars
{
    internal class CarInfoUpdateHandler(ICarRepository repo, ICarsQuery cars) : ICommandHandler<CarInfoUpdateCommand, CarDto>
    {
        public async Task<CarDto> HandleAsync(CarInfoUpdateCommand command)
        {
            var existing = (await repo.GetAsync(CarId.FromValue(command.Id)))
                .OrThrowIfNull(EntityErrors.CarNotFound);

            var name = Name.FromValue(command.Dto.Name);
            (await repo.GetIdByNameAsync(name))
                .ThrowIfNotNull(EntityErrors.CarNameAlreadyExists);

            var id = CarId.FromValue(command.Dto.Id);
            (await repo.GetIdByIdAsync(id))
                .ThrowIfNotNull(EntityErrors.CarIdAlreadyExists);

            existing.ChangeId(id);
            existing.ChangeName(name);

            await repo.UpdateAsync(existing);

            return (await cars.GetByIdAsync(id))
                .OrThrowIfNull(EntityErrors.CarNotFound); ;
        }
    }
}
