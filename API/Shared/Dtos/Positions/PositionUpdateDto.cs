namespace Shared.Dtos.Positions
{
    public record PositionUpdateDto(
        string Name,
        decimal PricePerHour
    );
}
