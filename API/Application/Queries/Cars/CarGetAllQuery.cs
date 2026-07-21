using Application.Dtos.Cars;

namespace Application.Queries.Cars
{
    public record CarGetAllQuery : IQuery<CarSimpleDto[]>;
}
