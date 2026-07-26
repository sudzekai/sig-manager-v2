using Application.CommandHandlers;
using Application.CommandHandlers.Users;
using Application.Commands.Users;
using Microsoft.Extensions.DependencyInjection;
using Shared.Dtos.Users;

namespace Application.DI
{
    public partial class DependencyInjection
    {
        private static void AddUserCommands(IServiceCollection collection)
        {
            collection.AddScoped<
                ICommandHandler<UserCreateCommand, UserDto>,
                UserCreateHandler
            >();

            collection.AddScoped<
                ICommandHandler<UserRoleUpdateCommand, UserDto>,
                UserRoleUpdateHandler
            >();

            collection.AddScoped<
                ICommandHandler<UserInfoUpdateCommand, UserDto>,
                UserInfoUpdateHandler
            >();
        }
    }
}
