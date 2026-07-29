using Domain.ValueObjects.Rights;
using Infrastructure.Context;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Rights;
using SqlKata;
using System.Data;
using System.Text;

namespace Infrastructure.Queries.Rights
{
    internal class RightsQuery(ISigDbContext db) : IRightsQuery
    {
        public async Task<RightSimpleDto[]> GetAllAsync(RightListRequest request)
        {
            var query = new Query("rights").
                Select("id", "code");

            if (request.CreatedAtStart != default)
                query.Where("created_at", ">=", request.CreatedAtStart);

            if (request.CreatedAtEnd != default)
                query.Where("created_at", "<=", request.CreatedAtEnd);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query.Where(q =>
                    q.WhereLike("code", $"{request.SearchTerm}%")
                );

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                var orderBy = request.OrderBy.ToLower() switch
                {
                    "code" => "code",
                    "created" or "createdat" or "created_at" => "created_at",
                    _ => "id"
                };

                if (request.OrderDirection.Equals("desc", StringComparison.OrdinalIgnoreCase))
                    query.OrderByDesc(orderBy);
                else
                    query.OrderBy(orderBy);
            }

            query.Limit(request.Limit);
            query.Offset(request.Offset);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            var idOrdinal = reader.GetOrdinal("id");
            var codeOrdinal = reader.GetOrdinal("code");

            List<RightSimpleDto> result = [];

            while (await reader.ReadAsync())
                result.Add(new(
                    reader.GetInt64(idOrdinal),
                    reader.GetString(codeOrdinal)
                ));

            return [.. result];
        }

        public async Task<RightDto?> GetByIdAsync(RightId id)
        {
            var query = new Query("rights")
                .Select("code")
                .Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new(
                    id.Value,
                    reader.GetString("code")
                );

            return null;
        }
    }
}
