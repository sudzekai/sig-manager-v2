using Shared.Dtos.Requests.List;

namespace Application.Queries.Shifts.CarouselShifts
{
    public record CarouselShiftGetAllQuery(CarouselShiftListRequest Request) : IQuery;
}
