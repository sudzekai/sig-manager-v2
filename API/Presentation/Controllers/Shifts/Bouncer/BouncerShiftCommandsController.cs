using Application.Commands.Shifts.BouncerShifts;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Shifts.Types.BouncerShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Bouncer
{
    [ApiController]
    [Route("shifts/bouncers")]
    public class BouncerShiftCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<BouncerShiftDto> Post([FromBody] BouncerShiftOpenDto body)
            => await dispatcher.ExecuteAsync<BouncerShiftDto>(new BouncerShiftOpenCommand(body));

        [HttpPut("{id}")]
        public async Task<BouncerShiftDto> Post([FromRoute] long id, [FromBody] BouncerShiftCloseDto body)
            => await dispatcher.ExecuteAsync<BouncerShiftDto>(new BouncerShiftCloseCommand(id, body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new BouncerShiftDeleteCommand(id));
    }
}
