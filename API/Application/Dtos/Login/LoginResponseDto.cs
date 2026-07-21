namespace Application.Dtos.Login
{
    public record LoginResponseDto(
        long UserId,
        string Username,
        string RoleName,
        string Token
    );
}
