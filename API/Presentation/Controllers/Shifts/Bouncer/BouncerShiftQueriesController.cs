using Application.Orchestrators.Queries;
using Application.Queries.Shifts.BouncerShifts;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Shifts.Types.BouncerShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Bouncer
{
    [ApiController]
    [Route("shifts/bouncers")]
    public class BouncerShiftQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<BouncerShiftSimpleDto[]> GetAll([FromQuery] BouncerShiftListRequest query)
            => await dispatcher.QueryAsync<BouncerShiftSimpleDto[]>(new BouncerShiftGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<BouncerShiftDto> GetAll(long id)
            => await dispatcher.QueryAsync<BouncerShiftDto>(new BouncerShiftGetByIdQuery(id));
    }
}
