using Application.Queries.Rights;
using Domain.ValueObjects.Rights;
using Infrastructure.Queries.Rights;
using Shared.Dtos.Rights;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.QueryHandlers.Rights
{
    internal class RightGetByIdHandler(IRightsQuery rights) : IQueryHandler<RightGetByIdQuery, RightDto>
    {
        public async Task<RightDto> QueryAsync(RightGetByIdQuery query)
            => (await rights.GetByIdAsync(RightId.FromValue(query.Id)))
                    .OrThrowIfNull(EntityErrors.RightNotFound);
                
    }
}
