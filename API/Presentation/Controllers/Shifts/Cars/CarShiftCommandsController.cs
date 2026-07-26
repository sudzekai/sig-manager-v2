using Application.Commands.Shifts.CarShifts;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Shifts.Types.CarShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Cars
{
    [ApiController]
    [Route("shifts/cars")]
    public class BouncerShiftCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<CarShiftDto> Post([FromBody] CarShiftOpenDto body)
            => await dispatcher.ExecuteAsync<CarShiftDto>(new CarShiftOpenCommand(body));

        [HttpPut("{id}")]
        public async Task<CarShiftDto> Post([FromRoute] long id, [FromBody] CarShiftCloseDto body)
            => await dispatcher.ExecuteAsync<CarShiftDto>(new CarShiftCloseCommand(id, body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new CarShiftDeleteCommand(id));
    }
}
