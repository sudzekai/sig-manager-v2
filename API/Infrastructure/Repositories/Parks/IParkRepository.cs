using Domain.Models.Parks;
using Domain.ValueObjects.Parks;

namespace Infrastructure.Repositories.Parks
{
    public interface IParkRepository
    {
        Task<ParkId> AddAsync(Park park);
        Task<bool> DeleteAsync(ParkId id);
        Task<Park?> GetAsync(ParkId id);
        Task<ParkId?> GetIdByNameAsync(Name name);
        Task UpdateAsync(Park park);
    }
}