using Application.Dtos.Positions;
using Application.Dtos.Users;

namespace Application.Dtos
{
    public record UserPositionDto(
        UserSimpleDto User,
        PositionSimpleDto Position,
        DateTime JoinedAt,
        DateTime? LeftAt
    );
}
