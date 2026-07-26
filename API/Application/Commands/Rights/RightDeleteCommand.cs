using Application.Objects;

namespace Application.Commands.Rights
{
    public record RightDeleteCommand(long Id) : ICommand;
}
