using Application.Commands.Positions;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Positions;
using System.Threading.Tasks;

namespace Presentation.Controllers.Positions
{
    [ApiController]
    [Route("positions")]
    public class PositionCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<PositionDto> Post([FromBody] PositionCreateDto body)
            => await dispatcher.ExecuteAsync<PositionDto>(new PositionCreateCommand(body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new PositionDeleteCommand(id));
    }
}
