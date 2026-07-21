using Application.Objects;

namespace Application.Commands.Cars
{
    public record CarDeleteCommand(long Id) : ICommand<Unit>;
}
