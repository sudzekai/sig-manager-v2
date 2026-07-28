using Application.Queries.Parks;
using Domain.ValueObjects.Parks;
using Infrastructure.Queries.Parks;
using Shared.Dtos.Parks;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.QueryHandlers.Parks
{
    internal class ParkGetByIdHandler(IParksQuery parks) : IQueryHandler<ParkGetByIdQuery, ParkDto>
    {
        public async Task<ParkDto> QueryAsync(ParkGetByIdQuery query)
            => (await parks.GetByIdAsync(ParkId.FromValue(query.Id)))
                    .OrThrowIfNull(EntityErrors.ParkNotFound);
                
    }
}
