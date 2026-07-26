using Shared.Dtos.Requests.List;

namespace Application.Queries.Shifts.PopcornShifts
{
    public record PopcornShiftGetAllQuery(PopcornShiftListRequest Request) : IQuery;
}
