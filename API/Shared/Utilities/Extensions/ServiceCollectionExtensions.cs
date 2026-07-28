using Microsoft.Extensions.DependencyInjection;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Exceptions;

namespace Shared.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedСhecked(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType)
        {
            var constructor = implementationType.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First();

            var missingDependencies = constructor.GetParameters()
                .Select(p => p.ParameterType)
                .Where(type => !services.Any(x => x.ServiceType == type))
                .ToArray();

            if (missingDependencies.Length > 0)
            {
                throw new AppException(
                    InternalErrors.DependencyNotImplemented,
                    $"Failed to register type '{implementationType.Name}'. Missing dependencies: {string.Join(", ", missingDependencies.Select(t => t.Name))}");
            }

            services.AddScoped(serviceType, implementationType);
        }
    }
}
