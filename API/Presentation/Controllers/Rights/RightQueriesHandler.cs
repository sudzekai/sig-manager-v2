using Application.Orchestrators.Queries;
using Application.Queries.Rights;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Rights;
using Shared.Dtos.Requests.List;
using System.Threading.Tasks;

namespace Presentation.Controllers.Rights
{
    [ApiController]
    [Route("rights")]
    public class RightQueriesHandler(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<RightSimpleDto[]> GetAll([FromQuery] RightListRequest query)
            => await dispatcher.QueryAsync<RightSimpleDto[]>(new RightGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<RightDto> GetAll(long id)
            => await dispatcher.QueryAsync<RightDto>(new RightGetByIdQuery(id));
    }
}
