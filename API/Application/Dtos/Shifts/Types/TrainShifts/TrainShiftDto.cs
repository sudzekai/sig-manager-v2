using Application.Dtos.Shifts.Base.CashShifts;
using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Types.TrainShifts.Base;

namespace Application.Dtos.Shifts.Types.TrainShifts
{
    public record TrainShiftDto(
        ShiftDto Shift,
        TrainTicketShiftDto Tickets,
        CashShiftDto? Cash
    );
}
