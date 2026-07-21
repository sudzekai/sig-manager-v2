using Application.Dtos.Parks;

namespace Application.Queries.Parks
{
    public record ParkGetAllQuery : IQuery<ParkSimpleDto[]>;
}
