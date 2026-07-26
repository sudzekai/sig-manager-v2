using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.CarShifts
{
    public record CarShiftSimpleDto(
        ShiftSimpleDto Shift,
        TicketShiftSimpleDto Tickets
    );
}
