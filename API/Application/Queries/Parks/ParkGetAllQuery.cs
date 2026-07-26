using Shared.Dtos.Parks;
using Shared.Dtos.Requests.List;

namespace Application.Queries.Parks
{
    public record ParkGetAllQuery(ParkListRequest Request) : IQuery;
}
