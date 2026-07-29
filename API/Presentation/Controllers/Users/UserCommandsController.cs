using Application.Commands.Users;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Users;
using System.Threading.Tasks;

namespace Presentation.Controllers.Users
{
    [ApiController]
    [Route("users")]
    public class UserCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<UserDto> Post([FromBody] UserCreateDto body)
            => await dispatcher.ExecuteAsync<UserDto>(new UserCreateCommand(body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new UserDeleteCommand(id));

        [HttpPut("{id}")]
        public async Task<UserDto> PutInfo([FromRoute] long id, [FromBody] UserInfoUpdateDto dto)
            => await dispatcher.ExecuteAsync<UserDto>(new UserInfoUpdateCommand(id, dto));

        [HttpPatch("{id}/role")]
        public async Task<UserDto> PatchRole([FromRoute] long id, [FromBody] UserRoleUpdateDto dto)
            => await dispatcher.ExecuteAsync<UserDto>(new UserRoleUpdateCommand(id, dto));

        [HttpPatch("{id}/password")]
        public async Task PatchPassword([FromRoute] long id, [FromBody] UserPasswordUpdateDto dto)
            => await dispatcher.ExecuteAsync<Unit>(new UserPasswordUpdateCommand(id, dto));
    }
}
