using Application.Dtos.Rights;

namespace Application.Commands.Rights
{
    public record RightCreateCommand(RightCreateDto Dto) : ICommand<RightDto>;
}
