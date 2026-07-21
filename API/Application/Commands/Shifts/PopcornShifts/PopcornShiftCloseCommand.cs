using Application.Dtos.Shifts.Types.PopcornShifts;

namespace Application.Commands.Shifts.PopcornShifts
{
    public record PopcornShiftCloseCommand(long Id, PopcornShiftCloseDto Dto) : ICommand<PopcornShiftDto>;
}
