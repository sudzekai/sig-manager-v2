using Shared.Dtos.Cars;

namespace Application.Commands.Cars
{
    public record CarInfoUpdateCommand(long Id, CarInfoUpdateDto Dto) : ICommand;
}
