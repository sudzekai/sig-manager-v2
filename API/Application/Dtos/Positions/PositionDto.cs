namespace Application.Dtos.Positions
{
    public record PositionDto(
        long Id,
        string Name,
        decimal PricePerHour
    );
}
