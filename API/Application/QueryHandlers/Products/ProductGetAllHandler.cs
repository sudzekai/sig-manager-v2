using Application.Queries.Products;
using Infrastructure.Queries.Products;
using Shared.Dtos.Products;

namespace Application.QueryHandlers.Products
{
    internal class ProductGetAllHandler(IProductsQuery products) : IQueryHandler<ProductGetAllQuery, ProductSimpleDto[]>
    {
        public async Task<ProductSimpleDto[]> QueryAsync(ProductGetAllQuery query)
            => await products.GetAllAsync(query.Request);
    }
}
