using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Types.TrainShifts.Base;

namespace Shared.Dtos.Shifts.Types.TrainShifts
{
    public record TrainShiftOpenDto(
        ShiftOpenDto Shift,
        TrainTicketShiftOpenDto Tickets
    );
}
