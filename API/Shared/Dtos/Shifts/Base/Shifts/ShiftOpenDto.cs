using Shared.Dtos;
using Shared.Dtos.Cars;

namespace Shared.Dtos.Shifts.Base.Shifts
{
    public record ShiftOpenDto(
        int ParkId,
        UserPositionDto[] Employees,
        CarSimpleDto[] Cars
    );
}
