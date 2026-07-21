using Application.Dtos.Shifts.Types.CarShifts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Shifts.CarShifts
{
    public record CarShiftGetByIdQuery(long Id) : IQuery<CarShiftDto>;
}
