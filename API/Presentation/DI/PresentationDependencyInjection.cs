using Application.DI;
using Infrastructure.DI;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Presentation.Filters;

namespace Presentation.DI
{
    public static class PresentationDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDatabase(connectionString);
            services.AddUnitOfWork();

            services.AddRepositories();
            InfrastructureDependencyInjection.AddQueries(services);

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ILogger logger)
        {
            services.AddCommandDispatcher();
            services.AddCommandHandlers(logger);
            
            services.AddQueryDispatcher();
            services.AddQueryHandlers(logger);

            return services;
        }

        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddScoped<IExceptionFilter, ExceptionsFilter>();
            return services;
        }
    }
}
