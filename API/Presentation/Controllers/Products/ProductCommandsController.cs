using Application.Commands.Products;
using Application.Objects;
using Application.Orchestrators.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Products;
using System.Threading.Tasks;

namespace Presentation.Controllers.Products
{
    [ApiController]
    [Route("products")]
    public class ProductCommandsController(ICommandDispatcher dispatcher)
    {
        [HttpPost()]
        public async Task<ProductDto> Post([FromBody] ProductCreateDto body)
            => await dispatcher.ExecuteAsync<ProductDto>(new ProductCreateCommand(body));

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
            => await dispatcher.ExecuteAsync<Unit>(new ProductDeleteCommand(id));
    }
}
