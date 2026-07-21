namespace Application.Dtos.Positions
{
    public record PositionDto(
        int Id,
        string Name,
        decimal PricePerHour
    );
}
