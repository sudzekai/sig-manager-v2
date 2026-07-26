using Shared.Dtos.Parks;

namespace Application.Commands.Parks
{
    public record ParkCreateCommand(ParkCreateDto Dto) : ICommand;
}
