namespace Shared.Dtos.Users
{
    public record UserSimpleDto(
        long Id,
        string Username,
        string FullName
    );
}
