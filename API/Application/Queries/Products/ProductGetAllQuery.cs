using Shared.Dtos.Requests.List;

namespace Application.Queries.Products
{
    public record ProductGetAllQuery(ProductListRequest Request) : IQuery;
}
