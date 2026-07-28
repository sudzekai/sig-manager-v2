using Application.Orchestrators.Commands;
using Application.Orchestrators.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddCommandDispatcher(this IServiceCollection collection)
            => collection.AddScoped<ICommandDispatcher, CommandDispatcher>();

        public static IServiceCollection AddQueryDispatcher(this IServiceCollection collection)
            => collection.AddScoped<IQueryDispatcher, QueryDispatcher>();
    }
}
