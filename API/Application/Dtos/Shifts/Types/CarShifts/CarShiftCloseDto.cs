using Application.Dtos.Shifts.Base.CashShifts;
using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.CarShifts
{
    public record CarShiftCloseDto(
        ShiftCloseDto Shift,
        TicketShiftCloseDto Tickets,
        CashShiftCloseDto Cash
    );
}
