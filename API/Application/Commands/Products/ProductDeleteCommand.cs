namespace Application.Commands.Products
{
    public record ProductDeleteCommand(long Id) : ICommand;
}
