using Application.Commands.Shifts.PopcornShifts;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Shifts.Types.PopcornShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Popcorn
{
    [ApiController]
    [Route("shifts/popcorns")]
    public class PopcornShiftCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<PopcornShiftDto> Post([FromBody] PopcornShiftOpenDto body)
            => await dispatcher.ExecuteAsync<PopcornShiftDto>(new PopcornShiftOpenCommand(body));

        [HttpPut("{id}")]
        public async Task<PopcornShiftDto> Post([FromRoute] long id, [FromBody] PopcornShiftCloseDto body)
            => await dispatcher.ExecuteAsync<PopcornShiftDto>(new PopcornShiftCloseCommand(id, body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new PopcornShiftDeleteCommand(id));
    }
}
