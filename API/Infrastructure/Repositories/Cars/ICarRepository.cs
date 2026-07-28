using Domain.Models.Cars;
using Domain.ValueObjects.Cars;

namespace Infrastructure.Repositories.Cars
{
    public interface ICarRepository
    {
        Task<CarId> AddAsync(Car car);
        Task<bool> DeleteAsync(CarId id);
        Task<Car?> GetAsync(CarId id);
        Task<CarId?> GetIdByIdAsync(CarId id);
        Task<CarId?> GetIdByNameAsync(Name name);
        Task UpdateAsync(Car car);
    }
}