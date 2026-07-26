namespace Shared.Dtos.Shifts.Base.TicketShifts
{
    public record TicketShiftDto(
        int FirstTicket,
        int? LastTicket,
        decimal TicketPrice
    );
}
