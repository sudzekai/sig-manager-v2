using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.TrainShifts.Base
{
    public record TrainTicketShiftSimpleDto(
        int FirstTicket,
        int? LastTicket,
        int FirstTicketAlternative,
        int LastTicketAlternative
    ) : TicketShiftSimpleDto(FirstTicket, LastTicket);
}
