using Application.Queries.Positions;
using Infrastructure.Queries.Positions;
using Shared.Dtos.Positions;

namespace Application.QueryHandlers.Positions
{
    internal class PositionGetAllHandler(IPositionsQuery positions) : IQueryHandler<PositionGetAllQuery, PositionSimpleDto[]>
    {
        public async Task<PositionSimpleDto[]> QueryAsync(PositionGetAllQuery query)
            => await positions.GetAllAsync(query.Request);
    }
}
