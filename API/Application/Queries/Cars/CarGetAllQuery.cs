using Shared.Dtos.Requests.List;

namespace Application.Queries.Cars
{
    public record CarGetAllQuery(CarListRequest Request) : IQuery;
}
