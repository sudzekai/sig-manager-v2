using Application.Queries;
using Application.QueryHandlers;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Exceptions;

namespace Application.Orchestrators.Queries
{
    internal class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
    {
        public async Task<TResult> QueryAsync<TResult>(IQuery query)
            where TResult : class
        {
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = serviceProvider.GetService(handlerType)
              ?? throw new AppException(InternalErrors.ServiceNotFound, $"service {handlerType.Name.Split("`")[0]} for command {query.GetType().Name}");

            return await handler.QueryAsync((dynamic)query);
        }
    }
}
