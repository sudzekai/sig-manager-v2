using Shared.Dtos.Positions;

namespace Application.Queries.Positions
{
    public record PositionGetByIdQuery(long Id) : IQuery;
}
