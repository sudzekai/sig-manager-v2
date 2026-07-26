using Shared.Dtos.Shifts.Base.TicketShifts;

namespace Shared.Dtos.Shifts.Types.TrainShifts.Base
{
    public record TrainTicketShiftOpenDto(
        int FirstTicket,
        int FirstTicketAlternative,
        decimal TicketPrice,
        decimal TickerPriceAlternative
    ) : TicketShiftOpenDto(FirstTicket, TicketPrice);
}
