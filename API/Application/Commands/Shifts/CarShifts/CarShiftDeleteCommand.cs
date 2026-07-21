using Application.Objects;

namespace Application.Commands.Shifts.CarShifts
{
    public record CarShiftDeleteCommand(long Id) : ICommand<Unit>;
}
