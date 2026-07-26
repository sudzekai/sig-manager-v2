using Application.Commands;

namespace Application.CommandHandlers
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand
        where TResult : class
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
