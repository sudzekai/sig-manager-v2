using Application.Dtos.Shifts.Types.BouncerShifts;

namespace Application.Queries.Shifts.BouncerShifts
{
    public record BouncerShiftGetAll : IQuery<BouncerShiftSimpleDto[]>;
}
