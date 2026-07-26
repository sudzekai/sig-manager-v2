using Application.Orchestrators.Queries;
using Application.Queries.Shifts.TrainShifts;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Shifts.Types.TrainShifts;
using System.Threading.Tasks;

namespace Presentation.Controllers.Shifts.Train
{
    [ApiController]
    [Route("shifts/trains")]
    public class TrainShiftQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<TrainShiftSimpleDto[]> GetAll([FromQuery] TrainShiftListRequest query)
            => await dispatcher.QueryAsync<TrainShiftSimpleDto[]>(new TrainShiftGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<TrainShiftDto> GetAll(long id)
            => await dispatcher.QueryAsync<TrainShiftDto>(new TrainShiftGetByIdQuery(id));
    }
}
