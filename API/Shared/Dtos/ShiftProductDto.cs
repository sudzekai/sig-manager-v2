using Shared.Dtos.Products;

namespace Shared.Dtos
{
    public record ShiftProductDto(
        ProductSimpleDto Product,
        int Quantity
    );
}
