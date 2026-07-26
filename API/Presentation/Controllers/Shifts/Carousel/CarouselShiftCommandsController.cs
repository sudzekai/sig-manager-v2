using Application.Commands.Shifts.CarouselShifts;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Shifts.Types.CarouselShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Carousel
{
    [ApiController]
    [Route("shifts/carousels")]
    public class CarouselouselShiftCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<CarouselShiftDto> Post([FromBody] CarouselShiftOpenDto body)
            => await dispatcher.ExecuteAsync<CarouselShiftDto>(new CarouselShiftOpenCommand(body));

        [HttpPut("{id}")]
        public async Task<CarouselShiftDto> Post([FromRoute] long id, [FromBody] CarouselShiftCloseDto body)
            => await dispatcher.ExecuteAsync<CarouselShiftDto>(new CarouselShiftCloseCommand(id, body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new CarouselShiftDeleteCommand(id));
    }
}
