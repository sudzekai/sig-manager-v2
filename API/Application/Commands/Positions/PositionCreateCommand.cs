using Application.Dtos.Positions;

namespace Application.Commands.Positions
{
    public record PositionCreateCommand(PositionCreateDto Dto) : ICommand<PositionDto>;
}
