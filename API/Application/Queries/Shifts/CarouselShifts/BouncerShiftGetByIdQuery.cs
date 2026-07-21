using Application.Dtos.Shifts.Types.BouncerShifts;

namespace Application.Queries.Shifts.CarouselShifts
{
    public record BouncerShiftGetByIdQuery(long Id) : IQuery<BouncerShiftDto>;
}
