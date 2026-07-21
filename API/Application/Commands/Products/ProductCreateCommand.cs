using Application.Dtos.Products;

namespace Application.Commands.Products
{
    public record ProductCreateCommand(ProductCreateDto Dto) : ICommand<ProductDto>;
}
