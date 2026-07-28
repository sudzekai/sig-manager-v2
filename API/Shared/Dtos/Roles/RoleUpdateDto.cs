namespace Shared.Dtos.Roles
{
    public record RoleUpdateDto(
        string Name,
        long[] RoleIds
    );
}
