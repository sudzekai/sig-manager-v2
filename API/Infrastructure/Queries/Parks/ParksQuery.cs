using Domain.ValueObjects.Parks;
using Infrastructure.Context;
using Shared.Dtos.Parks;
using Shared.Dtos.Requests.List;
using SqlKata;
using System.Data;
using System.Text;

namespace Infrastructure.Queries.Parks
{
    internal class ParksQuery(ISigDbContext db) : IParksQuery
    {
        public async Task<ParkSimpleDto[]> GetAllAsync(ParkListRequest request)
        {
            var query = new Query("parks").
                Select("id", "name");

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query.Where(q =>
                    q.WhereLike("name", $"{request.SearchTerm}%")
                );

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                var orderBy = request.OrderBy.ToLower() switch
                {
                    "name" => "name",
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
            var nameOrdinal = reader.GetOrdinal("name");

            List<ParkSimpleDto> result = [];

            while (await reader.ReadAsync())
                result.Add(new(
                    reader.GetInt64(idOrdinal),
                    reader.GetString(nameOrdinal)
                ));

            return [.. result];
        }

        public async Task<ParkDto?> GetByIdAsync(ParkId id)
        {
            var query = new Query("parks")
                .Select("name")
                .Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new(
                    id.Value,
                    reader.GetString("name")
                );

            return null;
        }
    }
}
