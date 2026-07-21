using Application.Objects;

namespace Application.Commands.Users
{
    public record UserDeleteCommand(long Id) : ICommand<Unit>;
}
