using Shared.Dtos.Positions;
using Shared.Dtos.Users;

namespace Shared.Dtos
{
    public record UserPositionDto(
        UserSimpleDto User,
        PositionSimpleDto Position,
        DateTime JoinedAt,
        DateTime? LeftAt
    );
}
