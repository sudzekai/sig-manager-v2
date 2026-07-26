using Shared.Dtos.Shifts.Base.CashShifts;
using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.CarShifts
{
    public record CarShiftDto(
        ShiftDto Shift,
        TicketShiftDto Tickets,
        CashShiftDto? Cash
    );
}
