using Domain.ValueObjects.Parks;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Parks;

namespace Infrastructure.Queries.Parks
{
    public interface IParksQuery
    {
        Task<ParkDto?> GetByIdAsync(ParkId id);
        Task<ParkSimpleDto[]> GetAllAsync(ParkListRequest request);
    }
}