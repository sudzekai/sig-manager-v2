using Application.Dtos.Positions;

namespace Application.Queries.Positions
{
    public record PositionGetAllQuery : IQuery<PositionSimpleDto[]>;
}
