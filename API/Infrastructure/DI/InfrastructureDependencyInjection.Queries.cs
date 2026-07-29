using Infrastructure.Repositories.Cars;
using Infrastructure.Repositories.Parks;
using Infrastructure.Repositories.Positions;
using Infrastructure.Repositories.Products;
using Infrastructure.Repositories.Rights;
using Infrastructure.Repositories.Roles;
using Infrastructure.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Types.Exceptions;
using Shared.Utilities.Extensions;

namespace Infrastructure.DI
{
    public static partial class InfrastructureDependencyInjection
    {
        private static readonly Dictionary<Type, Type> _queries = new()
        {
            [typeof(ICarRepository)] = typeof(CarRepository),
            [typeof(IParkRepository)] = typeof(ParkRepository),
            [typeof(IPositionRepository)] = typeof(PositionRepository),
            [typeof(IProductRepository)] = typeof(ProductRepository),
            [typeof(IRightRepository)] = typeof(RightRepository),
            [typeof(IRoleRepository)] = typeof(RoleRepository),
            [typeof(IUserRepository)] = typeof(UserRepository)
        };

        public static IServiceCollection AddQueries(this IServiceCollection services, ILogger logger)
        {
            foreach (var (service, implementation) in _queries)
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
