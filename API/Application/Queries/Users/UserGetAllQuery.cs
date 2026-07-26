using Shared.Dtos.Requests.List;
using Shared.Dtos.Users;

namespace Application.Queries.Users
{
    public record UserGetAllQuery(UserListRequest Request) : IQuery;
}
