using Application.Dtos.Shifts.Types.PopcornShifts;

namespace Application.Commands.Shifts.PopcornShifts
{
    public record PopcornShiftOpenCommand(PopcornShiftOpenDto Dto) : ICommand<PopcornShiftDto>;
}
