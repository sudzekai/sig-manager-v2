namespace Application.Dtos.Users
{
    public record UserSimpleDto(
        int Id,
        string Username,
        string FullName
    );
}
