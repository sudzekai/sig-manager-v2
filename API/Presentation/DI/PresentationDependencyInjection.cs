using Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.DI
{
    public static class PresentationDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection collection, string connectionString)
        {
            collection.AddDatabase(connectionString);
            collection.AddUnitOfWork();
            collection.AddRepositories();
            collection.AddQueries();

            return collection;
        }
    }
}
