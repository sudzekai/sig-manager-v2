using Application.Dtos.Shifts.Base.CashShifts;
using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.CarouselShifts
{
    public record CarouselShiftDto(
        ShiftDto Shift,
        TicketShiftDto Tickets,
        CashShiftDto? Cash
    );
}
