using Shared.Dtos.Shifts.Types.BouncerShifts;

namespace Application.Commands.Shifts.BouncerShifts
{
    public record BouncerShiftOpenCommand(BouncerShiftOpenDto Dto) : ICommand;
}
