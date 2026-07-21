using Application.Dtos.Users;

namespace Application.Queries.Users
{
    public record UserGetAllQuery : IQuery<UserSimpleDto[]>;
}
