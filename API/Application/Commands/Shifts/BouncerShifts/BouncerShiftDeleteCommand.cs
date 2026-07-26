using Application.Objects;

namespace Application.Commands.Shifts.BouncerShifts
{
    public record BouncerShiftDeleteCommand(long Id) : ICommand;
}
