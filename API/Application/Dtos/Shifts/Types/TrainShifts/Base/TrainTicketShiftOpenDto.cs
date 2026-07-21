using Application.Dtos.Shifts.Base.TicketShifts;

namespace Application.Dtos.Shifts.Types.TrainShifts.Base
{
    public record TrainTicketShiftOpenDto(
        int FirstTicket,
        int FirstTicketAlternative,
        decimal TicketPrice,
        decimal TickerPriceAlternative
    ) : TicketShiftOpenDto(FirstTicket, TicketPrice);
}
