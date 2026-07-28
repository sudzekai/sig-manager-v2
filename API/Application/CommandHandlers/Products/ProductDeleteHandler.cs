using Application.Commands.Products;
using Application.Objects;
using Domain.ValueObjects.Products;
using Infrastructure.Repositories.Products;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Products
{
    public class ProductDeleteHandler(IProductRepository repo) : ICommandHandler<ProductDeleteCommand, Unit>
    {
        public async Task<Unit> HandleAsync(ProductDeleteCommand command)
        {
            (await repo.DeleteAsync(ProductId.FromValue(command.Id)))
                .ThrowIfFalse(EntityErrors.ProductNotFound);

            return Unit.Value;
        }
    }
}
