namespace Shared.Dtos.Positions
{
    public record PositionCreateDto(
        string Name,
        decimal PricePerHour
    );
}
