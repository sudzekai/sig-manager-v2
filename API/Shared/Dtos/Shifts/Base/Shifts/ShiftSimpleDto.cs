namespace Shared.Dtos.Shifts.Base.Shifts
{
    public record ShiftSimpleDto(
        long Id,
        DateTime OpenedAt,
        DateTime? ClosedAt,
        TimeSpan? Duration
    );
}
