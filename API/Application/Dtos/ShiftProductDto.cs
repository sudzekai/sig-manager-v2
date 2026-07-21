using Application.Dtos.Products;

namespace Application.Dtos
{
    public record ShiftProductDto(
        ProductSimpleDto Product,
        int Quantity
    );
}
