using Application.Dtos.Users;

namespace Application.Commands.Users
{
    public record UserCreateCommand(UserCreateDto Dto) : ICommand<UserDto>;
}
