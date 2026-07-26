using Application.Objects;

namespace Application.Commands.Roles
{
    public record RoleDeleteCommand(long Id) : ICommand;
}
