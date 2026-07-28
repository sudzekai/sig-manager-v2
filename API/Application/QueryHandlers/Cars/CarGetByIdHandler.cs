using Application.Queries.Cars;
using Domain.ValueObjects.Cars;
using Infrastructure.Queries.Cars;
using Shared.Dtos.Cars;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.QueryHandlers.Cars
{
    internal class CarGetByIdHandler(ICarsQuery cars) : IQueryHandler<CarGetByIdQuery, CarDto>
    {
        public async Task<CarDto> QueryAsync(CarGetByIdQuery query)
            => (await cars.GetByIdAsync(CarId.FromValue(query.Id)))
                    .OrThrowIfNull(EntityErrors.CarNotFound);
                
    }
}
