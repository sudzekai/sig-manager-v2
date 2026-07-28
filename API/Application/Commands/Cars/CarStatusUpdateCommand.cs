using Shared.Dtos.Cars;

namespace Application.Commands.Cars
{
    public record CarStatusUpdateCommand(long Id, CarStatusUpdateDto Dto) : ICommand;
}
