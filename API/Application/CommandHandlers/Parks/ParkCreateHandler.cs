using Application.Commands.Parks;
using Domain.Models.Parks;
using Domain.ValueObjects.Parks;
using Infrastructure.Queries.Parks;
using Infrastructure.Repositories.Parks;
using Shared.Dtos.Parks;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Parks
{
    internal class ParkCreateHandler(IParkRepository repo, IParksQuery parks) : ICommandHandler<ParkCreateCommand, ParkDto>
    {
        public async Task<ParkDto> HandleAsync(ParkCreateCommand command)
        {
            var dto = command.Dto;

            var name = Name.FromValue(dto.Name);
            (await repo.GetIdByNameAsync(name))
                .ThrowIfNotNull(EntityErrors.ParkNameAlreadyExists);

            var createdId = await repo.AddAsync(Park.Create(
                name
            ));

            return (await parks.GetByIdAsync(createdId))
                .OrThrowIfNull(EntityErrors.ParkNameAlreadyExists);
        }
    }
}
