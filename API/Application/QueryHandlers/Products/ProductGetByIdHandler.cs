using Application.Queries.Products;
using Domain.ValueObjects.Products;
using Infrastructure.Queries.Products;
using Shared.Dtos.Products;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.QueryHandlers.Products
{
    internal class ProductGetByIdHandler(IProductsQuery products) : IQueryHandler<ProductGetByIdQuery, ProductDto>
    {
        public async Task<ProductDto> QueryAsync(ProductGetByIdQuery query)
            => (await products.GetByIdAsync(ProductId.FromValue(query.Id)))
                    .OrThrowIfNull(EntityErrors.ProductNotFound);
                
    }
}
