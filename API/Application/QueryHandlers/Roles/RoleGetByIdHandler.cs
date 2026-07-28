using Application.Queries.Roles;
using Domain.ValueObjects.Roles;
using Infrastructure.Queries.Roles;
using Shared.Dtos.Roles;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.QueryHandlers.Roles
{
    internal class RoleGetByIdHandler(IRolesQuery roles) : IQueryHandler<RoleGetByIdQuery, RoleDto>
    {
        public async Task<RoleDto> QueryAsync(RoleGetByIdQuery query)
            => (await roles.GetByIdAsync(RoleId.FromValue(query.Id)))
                    .OrThrowIfNull(EntityErrors.RoleNotFound);
                
    }
}
