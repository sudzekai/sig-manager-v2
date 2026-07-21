using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.CarShifts
{
    public record CarShiftOpenDto(
        ShiftOpenDto Shift,
        TicketShiftOpenDto Tickets
    );
}
