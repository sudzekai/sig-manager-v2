using Application.Commands.Parks;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Parks;
using System.Threading.Tasks;

namespace Presentation.Controllers.Parks
{
    [ApiController]
    [Route("parks")]
    public class ParkCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<ParkDto> Post([FromBody] ParkCreateDto body)
            => await dispatcher.ExecuteAsync<ParkDto>(new ParkCreateCommand(body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new ParkDeleteCommand(id));
    }
}
