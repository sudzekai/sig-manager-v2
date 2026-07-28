using Shared.Dtos.Positions;

namespace Application.Commands.Positions
{
    public record PositionUpdateCommand(long Id, PositionUpdateDto Dto) : ICommand;
}
