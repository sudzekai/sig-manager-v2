using Application.Objects;

namespace Application.Commands.Parks
{
    public record ParkDeleteCommand(long Id) : ICommand<Unit>;
}
