namespace Shared.Dtos.Shifts.Base.CashShifts
{
    public record CashShiftDto(
        decimal Cash,
        decimal Cashless,
        decimal Total,
        decimal? Difference
    );
}
