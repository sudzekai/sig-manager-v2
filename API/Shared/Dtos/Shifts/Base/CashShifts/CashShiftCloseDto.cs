namespace Shared.Dtos.Shifts.Base.CashShifts
{
    public record CashShiftCloseDto(
        decimal Cash,
        decimal Cashless
    );
}
