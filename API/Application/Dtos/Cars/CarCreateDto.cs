namespace Application.Dtos.Cars
{
    public record CarCreateDto(
        long Id,
        string Name,
        string ControllerModel
    );
}
