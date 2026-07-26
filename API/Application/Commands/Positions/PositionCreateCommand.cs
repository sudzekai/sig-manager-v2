using Shared.Dtos.Positions;

namespace Application.Commands.Positions
{
    public record PositionCreateCommand(PositionCreateDto Dto) : ICommand;
}
