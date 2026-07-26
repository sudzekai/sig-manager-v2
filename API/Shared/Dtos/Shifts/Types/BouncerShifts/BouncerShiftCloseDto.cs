using Shared.Dtos.Shifts.Base.CashShifts;
using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.BouncerShifts
{
    public record BouncerShiftCloseDto(
        ShiftCloseDto Shift,
        TicketShiftCloseDto Tickets,
        CashShiftCloseDto Cash
    );
}
