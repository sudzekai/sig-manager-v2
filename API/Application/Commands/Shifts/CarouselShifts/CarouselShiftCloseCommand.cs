using Shared.Dtos.Shifts.Types.CarouselShifts;

namespace Application.Commands.Shifts.CarouselShifts
{
    public record CarouselShiftCloseCommand(long Id, CarouselShiftCloseDto Dto) : ICommand;
}
