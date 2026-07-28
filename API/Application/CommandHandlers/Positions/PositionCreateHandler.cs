using Application.Commands.Positions;
using Domain.Models.Positions;
using Domain.ValueObjects.Positions;
using Infrastructure.Queries.Positions;
using Infrastructure.Repositories.Positions;
using Shared.Dtos.Positions;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Positions
{
    internal class PositionCreateHandler(IPositionRepository repo, IPositionsQuery positions) : ICommandHandler<PositionCreateCommand, PositionDto>
    {
        public async Task<PositionDto> HandleAsync(PositionCreateCommand command)
        {
            var dto = command.Dto;

            var name = Name.FromValue(dto.Name);
            (await repo.GetIdByNameAsync(name))
                .ThrowIfNotNull(EntityErrors.PositionNameAlreadyExists);

            var createdId = await repo.AddAsync(Position.Create(
                name,
                PricePerHour.FromValue(dto.PricePerHour)
            ));

            return (await positions.GetByIdAsync(createdId))
                .OrThrowIfNull(EntityErrors.PositionNameAlreadyExists);
        }
    }
}
