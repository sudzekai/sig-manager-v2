using Application.Objects;

namespace Application.Commands.Shifts.PopcornShifts
{
    public record PopcornShiftDeleteCommand(long Id) : ICommand;
}
