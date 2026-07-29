using Domain.ValueObjects.Cars;
using Infrastructure.Context;
using Shared.Dtos.Cars;
using Shared.Dtos.Requests.List;
using SqlKata;
using System.Data;

namespace Infrastructure.Queries.Cars
{
    internal class CarsQuery(ISigDbContext db) : ICarsQuery
    {
        public async Task<CarSimpleDto[]> GetAllAsync(CarListRequest request)
        {
            var query = new Query("cars").
                Select("id", "name");

            if (!string.IsNullOrWhiteSpace(request.Status))
                _ = request.Status.ToLower() switch
                {
                    "working" => query.Where("status", "working"),
                    "broken" => query.Where("status", "broken"),
                    _ => null
                };

            if (request.CreatedAtStart != default)
                query.Where("created_at", ">=", request.CreatedAtStart);

            if (request.CreatedAtEnd != default)
                query.Where("created_at", "<=", request.CreatedAtEnd);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query.Where(q =>
                    q.WhereLike("name", $"{request.SearchTerm}%")
                );

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                var orderBy = request.OrderBy.ToLower() switch
                {
                    "name" => "name",
                    "created" or "createdat" or "created_at" => "created_at",
                    "status" => "status",
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

            List<CarSimpleDto> result = [];

            while (await reader.ReadAsync())
                result.Add(new(
                    reader.GetInt64(idOrdinal),
                    reader.GetString(nameOrdinal)
                ));

            return [.. result];
        }

        public async Task<CarDto?> GetByIdAsync(CarId id)
        {
            var query = new Query("cars")
                .Select("name", "status", "controller_model")
                .Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new(
                    id.Value,
                    reader.GetString("name"),
                    reader.GetString("status"),
                    reader.GetString("controller_model")
                );

            return null;
        }
    }
}
