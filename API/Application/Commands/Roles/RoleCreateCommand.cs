using Shared.Dtos.Roles;

namespace Application.Commands.Roles
{
    public record RoleCreateCommand(RoleCreateDto Dto) : ICommand;
}
