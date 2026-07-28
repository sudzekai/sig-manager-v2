using Application.Queries.Users;
using Domain.ValueObjects.Users;
using Infrastructure.Queries.Users;
using Shared.Dtos.Users;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.QueryHandlers.Users
{
    internal class UserGetByIdHandler(IUsersQuery users) : IQueryHandler<UserGetByIdQuery, UserDto>
    {
        public async Task<UserDto> QueryAsync(UserGetByIdQuery query)
            => (await users.GetByIdAsync(UserId.FromValue(query.Id)))
                    .OrThrowIfNull(EntityErrors.UserNotFound);
                
    }
}
