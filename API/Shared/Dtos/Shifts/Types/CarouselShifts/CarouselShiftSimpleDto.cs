using Shared.Dtos.Shifts.Base.Shifts;
using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.CarouselShifts
{
    public record CarouselShiftSimpleDto(
        ShiftSimpleDto Shift,
        TicketShiftSimpleDto Tickets
    );
}
