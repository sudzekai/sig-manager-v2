namespace Shared.Dtos.Users
{
    public record UserCreateDto(
        string Username,
        string Email,
        string FullName,
        string PhoneNumber,
        string Password
    );
}
