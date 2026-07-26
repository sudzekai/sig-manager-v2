using Shared.Dtos.Parks;

namespace Application.Queries.Parks
{
    public record ParkGetByIdQuery(long Id) : IQuery;
}
