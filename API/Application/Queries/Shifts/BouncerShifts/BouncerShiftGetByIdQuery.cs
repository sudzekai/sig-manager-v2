using Application.Dtos.Shifts.Types.BouncerShifts;

namespace Application.Queries.Shifts.BouncerShifts
{
    public record BouncerShiftGetByIdQueryd(long Id) : IQuery<BouncerShiftDto>;
}
