using Domain.Models.Rights;
using Domain.ValueObjects.Rights;
using Infrastructure.Context;
using MySql.Data.MySqlClient;
using SqlKata;
using System.Data;
using System.Text;

namespace Infrastructure.Repositories.Rights
{
    internal class RightRepository(ISigDbContext db) : IRightRepository
    {
        public async Task<RightId> AddAsync(Right right)
        {
            var query = new Query("cars")
                .AsInsert(new
                {
                    code = right.Code.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();

            return RightId.FromValue((int)((MySqlCommand)command).LastInsertedId);
        }

        public async Task<bool> DeleteAsync(RightId id)
        {
            var query = new Query("rights")
                .AsDelete().Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            var affected = await command.ExecuteNonQueryAsync();

            return affected > 0;
        }

        public async Task<Right?> GetAsync(RightId id)
        {
            var query = new Query("rights")
                .Select("code").Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return Right.Restore(
                    id,
                    Code.FromValue(reader.GetString("code"))
                );

            return null;
        }

        public async Task<RightId?> GetIdByCodeAsync(Code code)
        {
            var query = new Query("rights")
                .Select("id").Where("code", code.Value);

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return idObj is null ? null : RightId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task UpdateAsync(Right right)
        {
            var query = new Query("rights")
                .AsUpdate(new
                {
                    code = right.Code.Value
                }).Where("id", right.Id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}
