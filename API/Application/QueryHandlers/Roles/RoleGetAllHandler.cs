using Application.Queries.Roles;
using Infrastructure.Queries.Roles;
using Shared.Dtos.Roles;

namespace Application.QueryHandlers.Roles
{
    internal class RoleGetAllHandler(IRolesQuery roles) : IQueryHandler<RoleGetAllQuery, RoleSimpleDto[]>
    {
        public async Task<RoleSimpleDto[]> QueryAsync(RoleGetAllQuery query)
            => await roles.GetAllAsync(query.Request);
    }
}
