using Domain.ValueObjects.Positions;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Positions;

namespace Infrastructure.Queries.Positions
{
    public interface IPositionsQuery
    {
        Task<PositionDto?> GetByIdAsync(PositionId id);
        Task<PositionSimpleDto[]> GetAllAsync(PositionListRequest request);
    }
}