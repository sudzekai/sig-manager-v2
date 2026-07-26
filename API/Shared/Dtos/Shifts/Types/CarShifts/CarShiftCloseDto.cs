using Shared.Dtos.Shifts.Base.CashShifts;
using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.CarShifts
{
    public record CarShiftCloseDto(
        ShiftCloseDto Shift,
        TicketShiftCloseDto Tickets,
        CashShiftCloseDto Cash
    );
}
