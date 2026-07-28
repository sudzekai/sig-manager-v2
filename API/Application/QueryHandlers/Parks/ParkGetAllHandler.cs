using Application.Queries.Parks;
using Infrastructure.Queries.Parks;
using Shared.Dtos.Parks;

namespace Application.QueryHandlers.Parks
{
    internal class ParkGetAllHandler(IParksQuery parks) : IQueryHandler<ParkGetAllQuery, ParkSimpleDto[]>
    {
        public async Task<ParkSimpleDto[]> QueryAsync(ParkGetAllQuery query)
            => await parks.GetAllAsync(query.Request);
    }
}
