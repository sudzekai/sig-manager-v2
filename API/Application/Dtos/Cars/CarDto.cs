namespace Application.Dtos.Cars
{
    public record CarDto(
        int Id,
        string Name,
        string Status,
        string ControllerModel
    );
}
