using Application.Queries;

namespace Application.Orchestrators.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery query) where TResult : class;
    }
}