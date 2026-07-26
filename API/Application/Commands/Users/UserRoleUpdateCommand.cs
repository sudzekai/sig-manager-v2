using Shared.Dtos.Users;

namespace Application.Commands.Users
{
    public record UserRoleUpdateCommand(long Id, UserRoleUpdateDto Dto) : ICommand;
}
