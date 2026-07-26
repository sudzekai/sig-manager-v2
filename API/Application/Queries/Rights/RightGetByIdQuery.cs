using Shared.Dtos.Rights;

namespace Application.Queries.Rights
{
    public record RightGetByIdQuery(long Id) : IQuery;
}
