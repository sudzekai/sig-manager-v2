using Application.Commands;

namespace Application.CommandHandlers
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : class
    {
        Task<TResult> ExecuteAsync(TCommand command);
    }
}
