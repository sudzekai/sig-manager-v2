using Application.Objects;

namespace Application.Commands.Shifts.TrainShifts
{
    public record TrainShiftDeleteCommand(long Id) : ICommand;
}
