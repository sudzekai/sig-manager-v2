using Application.Dtos.Shifts.Types.PopcornShifts;

namespace Application.Queries.Shifts.TrainShifts
{
    public record TrainShiftGetAllQuery : IQuery<PopcornShiftSimpleDto[]>;
}
