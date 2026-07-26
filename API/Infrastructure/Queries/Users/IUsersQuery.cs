using Domain.ValueObjects.Users;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Users;

namespace Infrastructure.Queries.Users
{
    public interface IUsersQuery
    {
        Task<UserDto?> GetByIdAsync(UserId id);
        Task<UserSimpleDto[]> GetAllAsync(UserListRequest request);
    }
}