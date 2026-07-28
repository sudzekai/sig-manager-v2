using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Types.Exceptions;
using Shared.Utilities.Extensions;

namespace Application.DI
{
    public static partial class DependencyInjection
    {
        private static readonly Dictionary<Type, Type> _queryHandlers = new()
        {
        };

        public static IServiceCollection AddQueryHandlers(this IServiceCollection services, ILogger logger)
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
