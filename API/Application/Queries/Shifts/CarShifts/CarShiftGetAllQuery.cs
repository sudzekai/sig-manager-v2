using Application.Dtos.Shifts.Types.CarShifts;

namespace Application.Queries.Shifts.CarShifts
{
    public record CarShiftGetAllQuery : IQuery<CarShiftSimpleDto[]>;
}
