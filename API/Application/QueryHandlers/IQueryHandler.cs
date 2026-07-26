using Application.Queries;

namespace Application.QueryHandlers
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery
        where TResult : class
    {
        Task<TResult> QueryAsync(TQuery query);
    }
}
