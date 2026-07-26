using Application.Commands.Shifts.TrainShifts;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Shifts.Types.TrainShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Train
{
    [ApiController]
    [Route("shifts/trains")]
    public class TrainShiftCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<TrainShiftDto> Post([FromBody] TrainShiftOpenDto body)
            => await dispatcher.ExecuteAsync<TrainShiftDto>(new TrainShiftOpenCommand(body));

        [HttpPut("{id}")]
        public async Task<TrainShiftDto> Post([FromRoute] long id, [FromBody] TrainShiftCloseDto body)
            => await dispatcher.ExecuteAsync<TrainShiftDto>(new TrainShiftCloseCommand(id, body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new TrainShiftDeleteCommand(id));
    }
}
