using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.BouncerShifts
{
    public record BouncerShiftSimpleDto(
        ShiftSimpleDto Shift,
        TicketShiftSimpleDto Tickets
    );
}
