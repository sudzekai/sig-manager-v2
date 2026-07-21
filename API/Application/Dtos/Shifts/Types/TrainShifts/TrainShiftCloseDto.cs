using Application.Dtos.Shifts.Base.CashShifts;
using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Types.TrainShifts.Base;

namespace Application.Dtos.Shifts.Types.TrainShifts
{
    public record TrainShiftCloseDto(
        ShiftCloseDto Shift,
        TrainTicketShiftCloseDto Tickets,
        CashShiftCloseDto Cash
    );
}
