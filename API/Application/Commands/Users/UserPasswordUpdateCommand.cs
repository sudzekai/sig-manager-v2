using Shared.Dtos.Users;

namespace Application.Commands.Users
{
    public record UserPasswordUpdateCommand(long Id, UserPasswordUpdateDto Dto) : ICommand;
}
