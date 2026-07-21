using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.TrainShifts.Base
{
    public record TrainTicketShiftCloseDto(
        int LastTicket,
        int LastTicketAlternative
    ) : TicketShiftCloseDto(LastTicket);
}
