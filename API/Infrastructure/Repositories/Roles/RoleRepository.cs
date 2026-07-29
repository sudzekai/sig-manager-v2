using Domain.Models.Rights;
using Domain.Models.Roles;
using Domain.ValueObjects.Rights;
using Domain.ValueObjects.Roles;
using Infrastructure.Context;
using MySql.Data.MySqlClient;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Repositories.Roles
{
    internal class RoleRepository(ISigDbContext db) : IRoleRepository
    {
        public async Task<RoleId> AddAsync(Role role)
        {
            var query = new Query("roles")
                .AsInsert(new
                {
                    name = role.Name.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();

            return RoleId.FromValue((int)((MySqlCommand)command).LastInsertedId);
        }

        public async Task<bool> DeleteAsync(RoleId id)
        {
            var query = new Query("roles")
                .AsDelete().Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            var affected = await command.ExecuteNonQueryAsync();

            return affected > 0;
        }

        public async Task<Role?> GetAsync(RoleId id)
        {
            var query = new Query("roles")
                .Select("name", "created_at").Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return Role.Restore(
                    id,
                    Name.FromValue(reader.GetString("name")),
                    reader.GetDateTime("created_at")
                );

            return null;
        }

        public async Task<RoleId?> GetIdByNameAsync(Name name)
        {
            var query = new Query("roles")
                .Select("id").Where("name", name.Value);

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return idObj is null ? null : RoleId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task UpdateAsync(Role role)
        {
            var query = new Query("roles")
                .AsUpdate(new
                {
                    name = role.Name.Value
                }).Where("id", role.Id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}
