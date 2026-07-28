using Application.Commands.Rights;
using Domain.Models.Rights;
using Domain.ValueObjects.Rights;
using Infrastructure.Queries.Rights;
using Infrastructure.Repositories.Rights;
using Shared.Dtos.Rights;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Rights
{
    internal class RightCreateHandler(IRightRepository repo, IRightsQuery rights) : ICommandHandler<RightCreateCommand, RightDto>
    {
        public async Task<RightDto> HandleAsync(RightCreateCommand command)
        {
            var dto = command.Dto;

            var code = Code.FromValue(dto.Code);
            (await repo.GetIdByCodeAsync(code))
                .ThrowIfNotNull(EntityErrors.RightCodeAlreadyExists);

            var createdId = await repo.AddAsync(Right.Create(
                code
            ));

            return (await rights.GetByIdAsync(createdId))
                .OrThrowIfNull(EntityErrors.RightCodeAlreadyExists);
        }
    }
}
