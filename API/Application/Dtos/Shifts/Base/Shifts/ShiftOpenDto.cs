using Application.Dtos.Cars;

namespace Application.Dtos.Shifts.Base.Shifts
{
    public record ShiftOpenDto(
        int ParkId,
        UserPositionDto[] Employees,
        CarSimpleDto[] Cars
    );
}
