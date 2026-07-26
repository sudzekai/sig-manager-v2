using Shared.Dtos.Shifts.Types.TrainShifts;

namespace Application.Commands.Shifts.TrainShifts
{
    public record TrainShiftCloseCommand(long Id, TrainShiftCloseDto Dto) : ICommand;
}
