using Domain.ValueObjects.Users;
using Infrastructure.Context;
using Shared.Dtos.Requests.List;
using Shared.Dtos.Users;
using SqlKata;
using System.Data;

namespace Infrastructure.Queries.Users
{
    internal class UsersQuery(ISigDbContext db) : IUsersQuery
    {
        public async Task<UserDto?> GetByIdAsync(UserId id)
        {
            var query = new Query("users")
                .Select("role_id", "username", "email", "full_name", "phone_number")
                .Where(new
                {
                    id = id.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new(
                    id.Value,
                    reader.GetInt64("role_id"),
                    reader.GetString("username"),
                    reader.GetString("email"),
                    reader.GetString("full_name"),
                    reader.GetString("phone_number")
                );

            return null;
        }

        public async Task<UserSimpleDto[]> GetAllAsync(UserListRequest request)
        {
            var query = new Query("users")
                .Select("id", "username", "full_name");

            if (request.RoleId != default)
                query.Where("role_id", request.RoleId);

            if (request.CreatedAtStart != default)
                query.Where("created_at", ">=", request.CreatedAtStart);

            if (request.CreatedAtEnd != default)
                query.Where("created_at", "<=", request.CreatedAtEnd);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query.Where(q =>
                    q.WhereLike("username", $"{request.SearchTerm}%")
                     .OrWhere("phone_number_last_four", request.SearchTerm)
                     .OrWhereLike("full_name", $"%{request.SearchTerm}%")
                     .OrWhereLike("email", $"{request.SearchTerm}%")
                );
            }

            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                var orderBy = request.OrderBy.ToLower() switch
                {
                    "username" => "username",
                    "created" => "created_at",
                    "fullname" => "full_name",
                    "role" => "role_id",
                    "email" => "email",
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

            List<UserSimpleDto> result = [];

            var idOrdinal = reader.GetOrdinal("id");
            var usernameOrdinal = reader.GetOrdinal("username");
            var fullNameOrdinal = reader.GetOrdinal("full_name");

            while (await reader.ReadAsync())
            {
                result.Add(new(
                    reader.GetInt64(idOrdinal),
                    reader.GetString(usernameOrdinal),
                    reader.GetString(fullNameOrdinal)
                ));
            }

            return [.. result];
        }
    }
}
