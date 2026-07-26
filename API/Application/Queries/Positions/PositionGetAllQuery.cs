using Shared.Dtos.Requests.List;

namespace Application.Queries.Positions
{
    public record PositionGetAllQuery(PositionListRequest Request) : IQuery;
}
