using Application.Queries.Rights;
using Infrastructure.Queries.Rights;
using Shared.Dtos.Rights;

namespace Application.QueryHandlers.Rights
{
    internal class RightGetAllHandler(IRightsQuery rights) : IQueryHandler<RightGetAllQuery, RightSimpleDto[]>
    {
        public async Task<RightSimpleDto[]> QueryAsync(RightGetAllQuery query)
            => await rights.GetAllAsync(query.Request);
    }
}
