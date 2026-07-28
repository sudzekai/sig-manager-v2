using Domain.ValueObjects.Products;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Products;

namespace Infrastructure.Queries.Products
{
    public interface IProductsQuery
    {
        Task<ProductDto?> GetByIdAsync(ProductId id);
        Task<ProductSimpleDto[]> GetAllAsync(ProductListRequest request);
    }
}