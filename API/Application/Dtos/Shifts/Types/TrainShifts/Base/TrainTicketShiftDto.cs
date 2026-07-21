using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.TrainShifts.Base
{
    public record TrainTicketShiftDto(
        int FirstTicket,
        int FirstTicketAlternative,
        int? LastTicket,
        int? LastTicketAlternative,
        decimal TicketPrice,
        decimal TicketPriceAlternative
    ) : TicketShiftDto(FirstTicket, LastTicket, TicketPrice);
}
