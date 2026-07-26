using Application.Commands.Rights;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Rights;
using System.Threading.Tasks;

namespace Presentation.Controllers.Rights
{
    [ApiController]
    [Route("rights")]
    public class RightCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<RightDto> Post([FromBody] RightCreateDto body)
            => await dispatcher.ExecuteAsync<RightDto>(new RightCreateCommand(body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new RightDeleteCommand(id));
    }
}
