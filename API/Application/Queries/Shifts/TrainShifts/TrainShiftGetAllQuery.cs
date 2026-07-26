using Shared.Dtos.Requests.List;

namespace Application.Queries.Shifts.TrainShifts
{
    public record TrainShiftGetAllQuery(TrainShiftListRequest Request) : IQuery;
}
