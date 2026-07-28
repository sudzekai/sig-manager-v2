using Application.Commands.Roles;
using Domain.Models.Roles;
using Domain.ValueObjects.Roles;
using Infrastructure.Queries.Roles;
using Infrastructure.Repositories.Roles;
using Shared.Dtos.Roles;
using Shared.Types.Errors.ApplicationError.Extensions;
using Shared.Types.Errors.Dictionaries.Entities;

namespace Application.CommandHandlers.Roles
{
    internal class RoleCreateHandler(IRoleRepository repo, IRolesQuery Roles) : ICommandHandler<RoleCreateCommand, RoleDto>
    {
        public async Task<RoleDto> HandleAsync(RoleCreateCommand command)
        {
            var dto = command.Dto;

            var name = Name.FromValue(dto.Name);
            (await repo.GetIdByNameAsync(name))
                .ThrowIfNotNull(EntityErrors.RoleNameAlreadyExists);

            var createdId = await repo.AddAsync(Role.Create(
                name
            ));

            return (await Roles.GetByIdAsync(createdId))
                .OrThrowIfNull(EntityErrors.RoleNameAlreadyExists);
        }
    }
}
