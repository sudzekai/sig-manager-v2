using Domain.Models.Roles;
using Domain.ValueObjects.Roles;

namespace Infrastructure.Repositories.Roles
{
    public interface IRoleRepository
    {
        Task<RoleId> AddAsync(Role role);
        Task<bool> DeleteAsync(RoleId id);
        Task<Role?> GetAsync(RoleId id);
        Task<RoleId?> GetIdByNameAsync(Name name);
        Task UpdateAsync(Role role);
    }
}