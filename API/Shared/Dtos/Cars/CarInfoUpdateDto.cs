namespace Shared.Dtos.Cars
{
    public record class CarInfoUpdateDto(
        int Id,
        string Name,
        string ControllerModel
    );
}
