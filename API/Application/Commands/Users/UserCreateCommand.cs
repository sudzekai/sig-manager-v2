using Shared.Dtos.Users;

namespace Application.Commands.Users
{
    public record UserCreateCommand(UserCreateDto Dto) : ICommand;
}
