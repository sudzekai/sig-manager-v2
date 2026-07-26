using Application.Orchestrators.Queries;
using Application.Queries.Products;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Products;
using Shared.Dtos.Requests.List;
using System.Threading.Tasks;

namespace Presentation.Controllers.Products
{
    [ApiController]
    [Route("products")]
    public class ProductQueriesController(IQueryDispatcher dispatcher)
    {
        [HttpGet]
        public async Task<ProductSimpleDto[]> GetAll([FromQuery] ProductListRequest query)
                    => await dispatcher.QueryAsync<ProductSimpleDto[]>(new ProductGetAllQuery(query));

        [HttpGet("{id}")]
        public async Task<ProductDto> GetAll(long id)
            => await dispatcher.QueryAsync<ProductDto>(new ProductGetByIdQuery(id));
    }
}
