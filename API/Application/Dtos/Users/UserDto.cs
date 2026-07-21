namespace Application.Dtos.Users
{
    public record UserDto(
        long Id,
        int RoleId,
        string Username,
        string Email,
        string FullName,
        string PhoneNumber
    );
}
