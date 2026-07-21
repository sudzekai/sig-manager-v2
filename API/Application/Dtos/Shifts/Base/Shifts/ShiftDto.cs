using Application.Dtos.Cars;

namespace Application.Dtos.Shifts.Base.Shifts
{
    public record ShiftDto(
        long Id,
        int ParkId,
        string Status,
        string Type,
        DateTime OpenedAt,
        DateTime? ClosedAt,
        TimeSpan? Duration,
        UserPositionDto[] Employees,
        ShiftProductDto[] Products,
        CarSimpleDto[] Cars
    );
}
