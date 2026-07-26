using Application.Orchestrators.Queries;
using Application.Queries.Shifts.CarouselShifts;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Shifts.Types.CarouselShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Carousel
{
    [ApiController]
    [Route("shifts/carousels")]
    public class CarouselShiftQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<CarouselShiftSimpleDto[]> GetAll([FromQuery] CarouselShiftListRequest query)
            => await dispatcher.QueryAsync<CarouselShiftSimpleDto[]>(new CarouselShiftGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<CarouselShiftDto> GetAll(long id)
            => await dispatcher.QueryAsync<CarouselShiftDto>(new CarouselShiftGetByIdQuery(id));
    }
}
