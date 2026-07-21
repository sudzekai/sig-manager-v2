using Application.Dtos.Rights;

namespace Application.Queries.Rights
{
    public record RightGetByIdQuery(long Id) : IQuery<RightDto>;
}
