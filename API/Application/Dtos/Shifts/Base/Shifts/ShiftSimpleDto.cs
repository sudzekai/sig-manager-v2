namespace Application.Dtos.Shifts.Base.Shifts
{
    public record ShiftSimpleDto(
        int Id,
        DateTime OpenedAt,
        DateTime? ClosedAt,
        TimeSpan? Duration
    );
}
