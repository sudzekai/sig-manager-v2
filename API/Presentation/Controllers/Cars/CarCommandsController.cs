using Application.Commands.Cars;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Cars;
using System.Threading.Tasks;

namespace Presentation.Controllers.Cars
{
    [ApiController]
    [Route("cars")]
    public class PositionCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<CarDto> Post([FromBody] CarCreateDto body)
            => await dispatcher.ExecuteAsync<CarDto>(new CarCreateCommand(body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new CarDeleteCommand(id));
    }
}
