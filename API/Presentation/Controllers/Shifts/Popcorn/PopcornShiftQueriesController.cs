using Application.Orchestrators.Queries;
using Application.Queries.Shifts.PopcornShifts;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Shifts.Types.PopcornShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Popcorn
{
    [ApiController]
    [Route("shifts/popcorns")]
    public class PopcornShiftQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<PopcornShiftSimpleDto[]> GetAll([FromQuery] PopcornShiftListRequest query)
            => await dispatcher.QueryAsync<PopcornShiftSimpleDto[]>(new PopcornShiftGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<PopcornShiftDto> GetAll(long id)
            => await dispatcher.QueryAsync<PopcornShiftDto>(new PopcornShiftGetByIdQuery(id));
    }
}
