using Shared.Dtos.Products;

namespace Application.Queries.Products
{
    public record ProductGetByIdQuery(long Id) : IQuery;
}
