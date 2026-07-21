using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.CarouselShifts
{
    public record CarouselShiftOpenDto(
        ShiftOpenDto Shift,
        TicketShiftOpenDto Tickets
    );
}
