using Shared.Dtos.Roles;

namespace Application.Commands.Roles
{
    public record RoleUpdateCommand(long Id, RoleUpdateDto Dto) : ICommand;
}
