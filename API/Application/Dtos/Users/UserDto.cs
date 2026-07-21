namespace Application.Dtos.Users
{
    public record UserDto(
        int Id,
        int RoleId,
        string Username,
        string Email,
        string FullName,
        string PhoneNumber
    );
}
