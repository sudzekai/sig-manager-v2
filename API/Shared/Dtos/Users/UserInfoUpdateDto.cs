namespace Shared.Dtos.Users
{
    public record UserInfoUpdateDto(
        string Username,
        string Email,
        string FullName,
        string PhoneNumber
    );
}
