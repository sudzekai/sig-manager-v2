namespace Shared.Dtos.Positions
{
    public record PositionDto(
        long Id,
        string Name,
        decimal PricePerHour
    );
}
