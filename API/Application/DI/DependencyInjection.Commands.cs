using Application.CommandHandlers;
using Application.CommandHandlers.Cars;
using Application.CommandHandlers.Parks;
using Application.CommandHandlers.Positions;
using Application.CommandHandlers.Products;
using Application.CommandHandlers.Rights;
using Application.CommandHandlers.Roles;
using Application.CommandHandlers.Users;
using Application.Commands.Cars;
using Application.Commands.Parks;
using Application.Commands.Positions;
using Application.Commands.Products;
using Application.Commands.Rights;
using Application.Commands.Roles;
using Application.Commands.Users;
using Application.Objects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Dtos.Cars;
using Shared.Dtos.Parks;
using Shared.Dtos.Positions;
using Shared.Dtos.Products;
using Shared.Dtos.Rights;
using Shared.Dtos.Roles;
using Shared.Dtos.Users;
using Shared.Types.Exceptions;
using Shared.Utilities.Extensions;

namespace Application.DI
{
    public partial class DependencyInjection
    {
        private static readonly Dictionary<Type, Type> _commandHandlers = new()
        {
            [typeof(ICommandHandler<CarCreateCommand, CarDto>)] = typeof(CarCreateHandler),
            [typeof(ICommandHandler<CarDeleteCommand, Unit>)] = typeof(CarDeleteHandler),

            [typeof(ICommandHandler<ParkCreateCommand, ParkDto>)] = typeof(ParkCreateHandler),
            [typeof(ICommandHandler<ParkDeleteCommand, Unit>)] = typeof(ParkDeleteHandler),

            [typeof(ICommandHandler<PositionCreateCommand, PositionDto>)] = typeof(PositionCreateHandler),
            [typeof(ICommandHandler<PositionDeleteCommand, Unit>)] = typeof(PositionDeleteHandler),

            [typeof(ICommandHandler<ProductCreateCommand, ProductDto>)] = typeof(ProductCreateHandler),
            [typeof(ICommandHandler<ProductDeleteCommand, Unit>)] = typeof(ProductDeleteHandler),

            [typeof(ICommandHandler<RightCreateCommand, RightDto>)] = typeof(RightCreateHandler),
            [typeof(ICommandHandler<RightDeleteCommand, Unit>)] = typeof(RightDeleteHandler),

            [typeof(ICommandHandler<RoleCreateCommand, RoleDto>)] = typeof(RoleCreateHandler),
            [typeof(ICommandHandler<RoleDeleteCommand, Unit>)] = typeof(RoleDeleteHandler),

            [typeof(ICommandHandler<UserCreateCommand, UserDto>)] = typeof(UserCreateHandler),
            [typeof(ICommandHandler<UserDeleteCommand, Unit>)] = typeof(UserDeleteHandler),
            [typeof(ICommandHandler<UserRoleUpdateCommand, UserDto>)] = typeof(UserRoleUpdateHandler),
            [typeof(ICommandHandler<UserInfoUpdateCommand, UserDto>)] = typeof(UserInfoUpdateHandler),
            [typeof(ICommandHandler<UserPasswordUpdateCommand, Unit>)] = typeof(UserPasswordUpdateHandler)
        };

        public static IServiceCollection AddCommandHandlers(this IServiceCollection services, ILogger logger)
        {
            foreach (var (service, implementation) in _commandHandlers)
            {
                try
                {
                    services.AddScopedСhecked(service, implementation);
                }
                catch (AppException ex)
                {
                    logger.LogWarning(ex.ToString());
                }
            }

            return services;
        }
    }
}
