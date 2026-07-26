using Application.Commands.Users;
using Application.Objects;

namespace Application.CommandHandlers.Users
{
    internal class UserDeleteHandler : ICommandHandler<UserDeleteCommand, Unit>
    {
        public Task<Unit> HandleAsync(UserDeleteCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
