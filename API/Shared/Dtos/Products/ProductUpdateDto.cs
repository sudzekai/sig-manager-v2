using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.Products
{
    public record ProductUpdateDto(
        string Name,
        decimal Price
    );
}
