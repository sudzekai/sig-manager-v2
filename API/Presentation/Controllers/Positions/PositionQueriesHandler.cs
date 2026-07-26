using Application.Orchestrators.Queries;
using Application.Queries.Positions;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Positions;
using Shared.Dtos.Requests.List;
using System.Threading.Tasks;

namespace Presentation.Controllers.Positions
{
    [ApiController]
    [Route("positions")]
    public class PositionQueriesHandler(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<PositionSimpleDto[]> GetAll([FromQuery] PositionListRequest query)
            => await dispatcher.QueryAsync<PositionSimpleDto[]>(new PositionGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<PositionDto> GetAll(long id)
            => await dispatcher.QueryAsync<PositionDto>(new PositionGetByIdQuery(id));
    }
}
