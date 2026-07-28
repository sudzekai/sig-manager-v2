using Application.Queries.Users;
using Infrastructure.Queries.Users;
using Shared.Dtos.Users;

namespace Application.QueryHandlers.Users
{
    internal class UserGetAllHandler(IUsersQuery users) : IQueryHandler<UserGetAllQuery, UserSimpleDto[]>
    {
        public async Task<UserSimpleDto[]> QueryAsync(UserGetAllQuery query)
            => await users.GetAllAsync(query.Request);
    }
}
