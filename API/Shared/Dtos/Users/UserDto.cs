namespace Shared.Dtos.Users
{
    public record UserDto(
        long Id,
        long RoleId,
        string Username,
        string Email,
        string FullName,
        string PhoneNumber
    );
}
