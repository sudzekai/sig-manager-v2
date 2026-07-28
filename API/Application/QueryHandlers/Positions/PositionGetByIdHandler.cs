using Application.Queries.Positions;
using Domain.ValueObjects.Positions;
using Infrastructure.Queries.Positions;
using Shared.Dtos.Positions;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.QueryHandlers.Positions
{
    internal class PositionGetByIdHandler(IPositionsQuery positions) : IQueryHandler<PositionGetByIdQuery, PositionDto>
    {
        public async Task<PositionDto> QueryAsync(PositionGetByIdQuery query)
            => (await positions.GetByIdAsync(PositionId.FromValue(query.Id)))
                    .OrThrowIfNull(EntityErrors.PositionNotFound);
                
    }
}
