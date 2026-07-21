using Application.Objects;

namespace Application.Commands.Shifts.CarouselShifts
{
    public record CarouselShiftDeleteCommand(long Id) : ICommand<Unit>;
}
