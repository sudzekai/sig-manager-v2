using Application.Orchestrators.Queries;
using Application.Queries.Cars;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Cars;
using Shared.Dtos.Requests.List;
using System.Threading.Tasks;

namespace Presentation.Controllers.Cars
{
    [ApiController]
    [Route("cars")]
    public class PositionQueriesHandler(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<CarSimpleDto[]> GetAll([FromQuery] CarListRequest query)
            => await dispatcher.QueryAsync<CarSimpleDto[]>(new CarGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<CarDto> GetAll(long id)
            => await dispatcher.QueryAsync<CarDto>(new CarGetByIdQuery(id));
    }
}
