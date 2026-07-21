namespace Application.Dtos.Positions
{
    public record PositionCreateDto(
        string Name,
        decimal PricePerHour
    );
}
