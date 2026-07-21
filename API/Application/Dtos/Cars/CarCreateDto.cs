namespace Application.Dtos.Cars
{
    public record CarCreateDto(
        int Id,
        string Name,
        string ControllerModel
    );
}
