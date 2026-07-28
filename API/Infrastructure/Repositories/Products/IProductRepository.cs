using Domain.Models.Products;
using Domain.ValueObjects.Products;

namespace Infrastructure.Repositories.Products
{
    public interface IProductRepository
    {
        Task<ProductId> AddAsync(Product product);
        Task<bool> DeleteAsync(ProductId id);
        Task<Product?> GetAsync(ProductId id);
        Task<ProductId?> GetIdByNameAsync(Name name);
        Task UpdateAsync(Product product);
    }
}