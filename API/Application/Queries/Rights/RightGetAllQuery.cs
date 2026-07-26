using Shared.Dtos.Requests.List;

namespace Application.Queries.Rights
{
    public record RightGetAllQuery(RightListRequest Request) : IQuery;
}
