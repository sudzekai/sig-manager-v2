using Application.Dtos.Parks;

namespace Application.Commands.Parks
{
    public record ParkCreateCommand(ParkCreateDto Dto) : ICommand<ParkDto>;
}
