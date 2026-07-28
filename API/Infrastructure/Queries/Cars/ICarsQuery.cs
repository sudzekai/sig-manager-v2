using Domain.ValueObjects.Cars;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Cars;

namespace Infrastructure.Queries.Cars
{
    public interface ICarsQuery
    {
        Task<CarDto?> GetByIdAsync(CarId id);
        Task<CarSimpleDto[]> GetAllAsync(CarListRequest request);
    }
}