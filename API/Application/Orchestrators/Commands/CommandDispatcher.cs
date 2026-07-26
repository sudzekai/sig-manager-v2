using Application.CommandHandlers;
using Application.Commands;
using Shared.Types.Errors;
using Shared.Types.Exceptions;

namespace Application.Orchestrators.Commands
{
    internal class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
    {
        public async Task<TResult> ExecuteAsync<TResult>(ICommand command)
            where TResult : class
        {
            var handlerType = typeof(ICommandHandler<,>)
                .MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = serviceProvider.GetService(handlerType)
                ?? throw new AppException(InternalErrors.ServiceNotFound, $"service {handlerType.Name.Split("`")[0]} for command {command.GetType().Name}");

            return await handler.HandleAsync((dynamic)command);
        }
    }
}
