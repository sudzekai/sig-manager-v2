using Application.Commands;

namespace Application.Orchestrators.Commands
{
    public interface ICommandDispatcher
    {
        Task<TResult> ExecuteAsync<TResult>(ICommand command) where TResult : class;
    }
}