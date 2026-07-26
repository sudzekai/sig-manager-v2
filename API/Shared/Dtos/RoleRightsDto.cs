using Shared.Dtos.Rights;
using Shared.Dtos.Roles;

namespace Shared.Dtos
{
    public record RoleRightsDto(
        RoleDto Role,
        RightDto[] Rights
    );
}
