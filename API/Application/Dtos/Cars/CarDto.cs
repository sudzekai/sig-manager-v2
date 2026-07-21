namespace Application.Dtos.Cars
{
    public record CarDto(
        long Id,
        string Name,
        string Status,
        string ControllerModel
    );
}
