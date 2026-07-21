using Application.Dtos.Shifts.Types.PopcornShifts;

namespace Application.Queries.Shifts.PopcornShifts
{
    public record PopcornShiftGetAllQuery : IQuery<PopcornShiftSimpleDto[]>;
}
