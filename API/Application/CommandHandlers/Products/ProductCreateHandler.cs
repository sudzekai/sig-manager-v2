using Application.Commands.Products;
using Domain.Models.Products;
using Domain.ValueObjects.Products;
using Infrastructure.Queries.Products;
using Infrastructure.Repositories.Products;
using Shared.Dtos.Products;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Products
{
    internal class ProductCreateHandler(IProductRepository repo, IProductsQuery products) : ICommandHandler<ProductCreateCommand, ProductDto>
    {
        public async Task<ProductDto> HandleAsync(ProductCreateCommand command)
        {
            var dto = command.Dto;

            var name = Name.FromValue(dto.Name);
            (await repo.GetIdByNameAsync(name))
                .ThrowIfNotNull(EntityErrors.ProductNameAlreadyExists);

            var createdId = await repo.AddAsync(Product.Create(
                name,
                Price.FromValue(dto.Price)
            ));

            return (await products.GetByIdAsync(createdId))
                .OrThrowIfNull(EntityErrors.ProductNameAlreadyExists);
        }
    }
}
