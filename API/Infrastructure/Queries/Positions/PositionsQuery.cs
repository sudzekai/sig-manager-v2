using Domain.ValueObjects.Positions;
using Infrastructure.Context;
using Shared.Dtos.Positions;
using Shared.Dtos.Requests.List;
using SqlKata;
using System.Data;
using System.Text;

namespace Infrastructure.Queries.Positions
{
    internal class PositionsQuery(ISigDbContext db) : IPositionsQuery
    {
        public async Task<PositionSimpleDto[]> GetAllAsync(PositionListRequest request)
        {
            var query = new Query("positions").
                Select("id", "name");

            if (request.PricePerHourStart != default)
                query.Where("price_per_hour", ">=", request.PricePerHourStart);

            if (request.PricePerHourEnd != default)
                query.Where("price_per_hour", "<=", request.PricePerHourEnd);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query.Where(q =>
                    q.WhereLike("name", $"{request.SearchTerm}%")
                );

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                var orderBy = request.OrderBy.ToLower() switch
                {
                    "name" => "name",
                    "priceperhour" or "price_per_hour" => "price_per_hour",
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

            List<PositionSimpleDto> result = [];

            while (await reader.ReadAsync())
                result.Add(new(
                    reader.GetInt64(idOrdinal),
                    reader.GetString(nameOrdinal)
                ));

            return [.. result];
        }

        public async Task<PositionDto?> GetByIdAsync(PositionId id)
        {
            var query = new Query("positions")
                .Select("name", "price_per_hour")
                .Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new(
                    id.Value,
                    reader.GetString("name"),
                    reader.GetDecimal("price_per_hour")
                );

            return null;
        }
    }
}
