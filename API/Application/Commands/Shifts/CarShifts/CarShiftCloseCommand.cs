using Shared.Dtos.Shifts.Types.CarShifts;

namespace Application.Commands.Shifts.CarShifts
{
    public record CarShiftCloseCommand(long Id, CarShiftCloseDto Dto) : ICommand;
}
