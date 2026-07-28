using Domain.Models.Rights;
using Domain.ValueObjects.Rights;

namespace Infrastructure.Repositories.Rights
{
    public interface IRightRepository
    {
        Task<RightId> AddAsync(Right right);
        Task<bool> DeleteAsync(RightId id);
        Task<Right?> GetAsync(RightId id);
        Task<RightId?> GetIdByCodeAsync(Code code);
        Task UpdateAsync(Right right);
    }
}