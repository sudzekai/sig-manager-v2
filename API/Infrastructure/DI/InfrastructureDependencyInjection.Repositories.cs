using Infrastructure.Queries.Cars;
using Infrastructure.Queries.Parks;
using Infrastructure.Queries.Positions;
using Infrastructure.Queries.Products;
using Infrastructure.Queries.Rights;
using Infrastructure.Queries.Roles;
using Infrastructure.Queries.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Types.Exceptions;
using Shared.Utilities.Extensions;

namespace Infrastructure.DI
{
    public static partial class InfrastructureDependencyInjection
    {
        private static readonly Dictionary<Type, Type> _repositories = new()
        {
            [typeof(ICarsQuery)] = typeof(CarsQuery),
            [typeof(IParksQuery)] = typeof(ParksQuery),
            [typeof(IPositionsQuery)] = typeof(PositionsQuery),
            [typeof(IProductsQuery)] = typeof(ProductsQuery),
            [typeof(IRightsQuery)] = typeof(RightsQuery),
            [typeof(IRolesQuery)] = typeof(RolesQuery),
            [typeof(IUsersQuery)] = typeof(UsersQuery)
        };

        public static IServiceCollection AddRepositories(this IServiceCollection services, ILogger logger)
        {
            foreach (var (service, implementation) in _repositories)
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
