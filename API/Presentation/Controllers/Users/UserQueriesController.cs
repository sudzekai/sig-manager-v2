using Application.Orchestrators.Queries;
using Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Users;
using System.Threading.Tasks;

namespace Presentation.Controllers.Users
{
    [ApiController]
    [Route("users")]
    public class UserQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<UserSimpleDto[]> GetAll([FromQuery] UserListRequest query)
            => await dispatcher.QueryAsync<UserSimpleDto[]>(new UserGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<UserDto> GetAll(long id)
            => await dispatcher.QueryAsync<UserDto>(new UserGetByIdQuery(id));
    }
}
