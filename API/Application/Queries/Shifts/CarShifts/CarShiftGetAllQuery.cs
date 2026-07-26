using Shared.Dtos.Requests.List;

namespace Application.Queries.Shifts.CarShifts
{
    public record CarShiftGetAllQuery(CarShiftListRequest Request) : IQuery;
}
