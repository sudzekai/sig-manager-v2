using Shared.Dtos.Cars;

namespace Application.Queries.Cars
{
    public record CarGetByIdQuery(long Id) : IQuery;
}
