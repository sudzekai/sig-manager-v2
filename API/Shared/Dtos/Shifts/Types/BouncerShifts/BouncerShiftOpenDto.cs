using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.BouncerShifts
{
    public record BouncerShiftOpenDto(
        ShiftOpenDto Shift,
        TicketShiftOpenDto Tickets
    );
}
