using Shared.Dtos.Shifts.Types.CarouselShifts;

namespace Application.Commands.Shifts.CarouselShifts
{
    public record CarouselShiftOpenCommand(CarouselShiftOpenDto Dto) : ICommand;
}
