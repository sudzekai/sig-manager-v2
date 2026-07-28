using Domain.ValueObjects.Roles;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Roles;

namespace Infrastructure.Queries.Roles
{
    public interface IRolesQuery
    {
        Task<RoleDto?> GetByIdAsync(RoleId id);
        Task<RoleSimpleDto[]> GetAllAsync(RoleListRequest request);
    }
}