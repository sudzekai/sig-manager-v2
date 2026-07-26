using Application.Commands.Roles;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Roles;
using System.Threading.Tasks;

namespace Presentation.Controllers.Roles
{
    [ApiController]
    [Route("roles")]
    public class RoleCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<RoleDto> Post([FromBody] RoleCreateDto body)
            => await dispatcher.ExecuteAsync<RoleDto>(new RoleCreateCommand(body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new RoleDeleteCommand(id));
    }
}
