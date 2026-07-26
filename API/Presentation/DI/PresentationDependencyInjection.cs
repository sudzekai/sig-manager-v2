using Application.DI;
using Infrastructure.DI;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Filters;

namespace Presentation.DI
{
    public static class PresentationDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection collection, string connectionString)
        {
            collection.AddDatabase(connectionString);
            collection.AddUnitOfWork();

            collection.AddRepositories();
            InfrastructureDependencyInjection.AddQueries(collection);

            return collection;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddCommandDispatcher();
            collection.AddCommands();
            
            collection.AddQueryDispatcher();
            DependencyInjection.AddQueries(collection);

            return collection;
        }

        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddScoped<IExceptionFilter, ExceptionsFilter>();
            return services;
        }
    }
}
