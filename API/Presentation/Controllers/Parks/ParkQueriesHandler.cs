using Application.Orchestrators.Queries;
using Application.Queries.Parks;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Parks;
using System.Threading.Tasks;

namespace Presentation.Controllers.Parks
{
    [ApiController]
    [Route("parks")]
    public class ParkQueriesHandler(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<ParkSimpleDto[]> GetAll([FromQuery] ParkListRequest query)
            => await dispatcher.QueryAsync<ParkSimpleDto[]>(new ParkGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<ParkDto> GetAll(long id)
            => await dispatcher.QueryAsync<ParkDto>(new ParkGetByIdQuery(id));
    }
}
