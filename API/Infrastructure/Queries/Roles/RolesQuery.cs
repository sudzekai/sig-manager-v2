using Domain.ValueObjects.Roles;
using Infrastructure.Context;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Roles;
using SqlKata;
using System.Data;
using System.Text;

namespace Infrastructure.Queries.Roles
{
    internal class RolesQuery(ISigDbContext db) : IRolesQuery
    {
        public async Task<RoleSimpleDto[]> GetAllAsync(RoleListRequest request)
        {
            var query = new Query("roles").
                Select("id", "name");

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

            List<RoleSimpleDto> result = [];

            while (await reader.ReadAsync())
                result.Add(new(
                    reader.GetInt64(idOrdinal),
                    reader.GetString(nameOrdinal)
                ));

            return [.. result];
        }

        public async Task<RoleDto?> GetByIdAsync(RoleId id)
        {
            var query = new Query("roles")
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
