using Shared.Dtos.Parks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Parks
{
    public record ParkUpdateCommand(long Id, ParkUpdateDto Dto) : ICommand;
}
