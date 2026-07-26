using Shared.Dtos.Shifts.Base.CashShifts;
using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.BouncerShifts
{
    public record BouncerShiftDto(
        ShiftDto Shift,
        TicketShiftDto Tickets,
        CashShiftDto? Cash
    );
}
