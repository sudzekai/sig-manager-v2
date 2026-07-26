using Shared.Dtos.Shifts.Base.CashShifts;
using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Types.TrainShifts.Base;

namespace Shared.Dtos.Shifts.Types.TrainShifts
{
    public record TrainShiftCloseDto(
        ShiftCloseDto Shift,
        TrainTicketShiftCloseDto Tickets,
        CashShiftCloseDto Cash
    );
}
