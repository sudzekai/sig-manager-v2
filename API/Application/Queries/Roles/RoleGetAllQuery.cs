using Shared.Dtos.Requests.List;
using Shared.Dtos.Roles;

namespace Application.Queries.Roles
{
    public record RoleGetAllQuery(RoleListRequest Request) : IQuery;
}
