using Application.Dtos.Shifts.Base.CashShifts;
using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.BouncerShifts
{
    public record BouncerShiftDto(
        ShiftDto Shift,
        TicketShiftDto Tickets,
        CashShiftDto? Cash
    );
}
