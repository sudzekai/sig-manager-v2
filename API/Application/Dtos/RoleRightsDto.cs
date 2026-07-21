using Application.Dtos.Rights;
using Application.Dtos.Roles;

namespace Application.Dtos
{
    public record RoleRightsDto(
        RoleDto Role,
        RightDto[] Rights
    );
}
