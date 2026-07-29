using Application.Commands.Cars;
using Domain.Models.Cars;
using Domain.ValueObjects.Cars;
using Infrastructure.Queries.Cars;
using Infrastructure.Repositories.Cars;
using Shared.Dtos.Cars;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Cars
{
    internal class CarCreateHandler(ICarRepository repo, ICarsQuery cars) : ICommandHandler<CarCreateCommand, CarDto>
    {
        public async Task<CarDto> HandleAsync(CarCreateCommand command)
        {
            var dto = command.Dto;

            var id = CarId.FromValue(dto.Id);
            (await repo.GetIdByIdAsync(id))
                .ThrowIfNotNull(EntityErrors.CarIdAlreadyExists);

            var name = Name.FromValue(dto.Name);
            (await repo.GetIdByNameAsync(name))
                .ThrowIfNotNull(EntityErrors.CarNameAlreadyExists);

            var createdId = await repo.AddAsync(Car.Create(
                id,
                name,
                Status.Working,
                ControllerModel.FromValue(dto.ControllerModel)
            ));

            return (await cars.GetByIdAsync(createdId))
                .OrThrowIfNull(EntityErrors.CarNotFound);
        }
    }
}
