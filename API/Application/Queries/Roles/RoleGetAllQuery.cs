using Application.Dtos.Roles;

namespace Application.Queries.Roles
{
    public record RoleGetAllQuery : IQuery<RoleSimpleDto[]>;
}
