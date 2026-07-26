using Infrastructure.Context;
using Infrastructure.UOW;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DI
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection collection, string connectionString)
        {
            collection.AddScoped<ISigDbContext>(p =>
            {
                var logger = p.GetRequiredService<ILogger<ISigDbContext>>();
                return new SigDbContext(connectionString, logger);
            });

            return collection;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection collection)
        {
            return collection;
        }

        public static IServiceCollection AddQueries(this IServiceCollection collection)
        {
            return collection;
        
        }
        public static IServiceCollection AddUnitOfWork(this IServiceCollection collection)
        {
            collection.AddScoped<IUnitOfWork, UnitOfWork>();

            return collection;
        }
    }
}
