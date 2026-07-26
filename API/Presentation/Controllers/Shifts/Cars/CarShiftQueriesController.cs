using Application.Orchestrators.Queries;
using Application.Queries.Shifts.CarShifts;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Shifts.Types.CarShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Cars
{
    [ApiController]
    [Route("shifts/cars")]
    public class BouncerShiftQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<CarShiftSimpleDto[]> GetAll([FromQuery] CarShiftListRequest query)
            => await dispatcher.QueryAsync<CarShiftSimpleDto[]>(new CarShiftGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<CarShiftDto> GetAll(long id)
            => await dispatcher.QueryAsync<CarShiftDto>(new CarShiftGetByIdQuery(id));
    }
}
