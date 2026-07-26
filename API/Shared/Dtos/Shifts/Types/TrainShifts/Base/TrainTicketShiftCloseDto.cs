using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.TrainShifts.Base
{
    public record TrainTicketShiftCloseDto(
        int LastTicket,
        int LastTicketAlternative
    ) : TicketShiftCloseDto(LastTicket);
}
