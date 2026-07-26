using Shared.Dtos.Requests.List;

namespace Application.Queries.Shifts.BouncerShifts
{
    public record BouncerShiftGetAllQuery(BouncerShiftListRequest Request) : IQuery;
}
