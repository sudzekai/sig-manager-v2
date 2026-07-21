using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.CarouselShifts
{
    public record CarouselShiftSimpleDto(
        ShiftSimpleDto Shift,
        TicketShiftSimpleDto Tickets
    );
}
