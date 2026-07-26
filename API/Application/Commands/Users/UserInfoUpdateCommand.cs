using Shared.Dtos.Users;

namespace Application.Commands.Users
{
    public record UserInfoUpdateCommand(long Id, UserInfoUpdateDto Dto) : ICommand;
}
