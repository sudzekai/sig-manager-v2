using Shared.Dtos.Shifts.Types.CarShifts;

namespace Application.Commands.Shifts.CarShifts
{
    public record CarShiftOpenCommand(CarShiftOpenDto Dto) : ICommand;
}
