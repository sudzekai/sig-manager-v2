using Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Products
{
    public record ProductUpdateCommand(long Id, ProductUpdateDto Dto) : ICommand;
}
