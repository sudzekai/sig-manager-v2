using Domain.Models.Positions;
using Domain.ValueObjects.Positions;

namespace Infrastructure.Repositories.Positions
{
    public interface IPositionRepository
    {
        Task<PositionId> AddAsync(Position position);
        Task<bool> DeleteAsync(PositionId id);
        Task<Position?> GetAsync(PositionId id);
        Task<PositionId?> GetIdByNameAsync(Name name);
        Task UpdateAsync(Position position);
    }
}