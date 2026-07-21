using Application.Dtos.Shifts.Base.Shifts;
using Application.Dtos.Shifts.Types.TrainShifts.Base;

namespace Application.Dtos.Shifts.Types.TrainShifts
{
    public record TrainShiftOpenDto(
        ShiftOpenDto Shift,
        TrainTicketShiftOpenDto Tickets
    );
}
