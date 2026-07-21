using Application.Dtos.Shifts.Types.PopcornShifts;

namespace Application.Queries.Shifts.PopcornShifts
{
    public record PopcornShiftGetByIdQuery(long Id) : IQuery<PopcornShiftDto>;
}
