using Shared.Dtos.Shifts.Types.TrainShifts;

namespace Application.Commands.Shifts.TrainShifts
{
    public record TrainShiftOpenCommand(TrainShiftOpenDto Dto) : ICommand;
}
