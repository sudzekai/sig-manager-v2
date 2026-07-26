using Application.Objects;

namespace Application.Commands.Positions
{
    public record PositionDeleteCommand(long Id) : ICommand;
}
