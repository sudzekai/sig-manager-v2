using Application.Dtos.Cars;

namespace Application.Commands.Cars
{
    public record CarCreateCommand(CarCreateDto Dto) : ICommand<CarDto>;
}
