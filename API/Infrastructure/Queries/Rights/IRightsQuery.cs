using Domain.ValueObjects.Rights;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Rights;

namespace Infrastructure.Queries.Rights
{
    public interface IRightsQuery
    {
        Task<RightDto?> GetByIdAsync(RightId id);
        Task<RightSimpleDto[]> GetAllAsync(RightListRequest request);
    }
}