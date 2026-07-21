using Application.Dtos.Users;

namespace Application.Queries.Users
{
    public record UserGetByIdQuery(long Id) : IQuery<UserDto>;
}
