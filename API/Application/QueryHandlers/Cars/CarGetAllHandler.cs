using Application.Queries.Cars;
using Infrastructure.Queries.Cars;
using Shared.Dtos.Cars;

namespace Application.QueryHandlers.Cars
{
    internal class CarGetAllHandler(ICarsQuery cars) : IQueryHandler<CarGetAllQuery, CarSimpleDto[]>
    {
        public async Task<CarSimpleDto[]> QueryAsync(CarGetAllQuery query)
            => await cars.GetAllAsync(query.Request);
    }
}
