using Application.Orchestrators.Queries;
using Application.Queries.Roles;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Roles;
using System.Threading.Tasks;

namespace Presentation.Controllers.Roles
{
    [ApiController]
    [Route("roles")]
    public class RoleQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<RoleSimpleDto[]> GetAll([FromQuery] RoleListRequest query)
          => await dispatcher.QueryAsync<RoleSimpleDto[]>(new RoleGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<RoleDto> GetAll(long id)
            => await dispatcher.QueryAsync<RoleDto>(new RoleGetByIdQuery(id));
    }
}
