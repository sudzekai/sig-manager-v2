using Domain.Models.Parks;
using Domain.ValueObjects.Parks;
using Infrastructure.Context;
using MySql.Data.MySqlClient;
using SqlKata;
using System.Data;

namespace Infrastructure.Repositories.Parks
{
    internal class ParkRepository(ISigDbContext db) : IParkRepository
    {
        public async Task<ParkId> AddAsync(Park park)
        {
            var query = new Query("parks")
                .AsInsert(new
                {
                    name = park.Name.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();

            return ParkId.FromValue((int)((MySqlCommand)command).LastInsertedId);
        }

        public async Task<bool> DeleteAsync(ParkId id)
        {
            var query = new Query("parks")
                .AsDelete().Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            var affected = await command.ExecuteNonQueryAsync();

            return affected > 0;
        }

        public async Task<Park?> GetAsync(ParkId id)
        {
            var query = new Query("parks")
                .Select("name").Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return Park.Restore(
                    id,
                    Name.FromValue(reader.GetString("name"))
                );

            return null;
        }

        public async Task<ParkId?> GetIdByNameAsync(Name name)
        {
            var query = new Query("parks")
                .Select("id").Where("name", name.Value);

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return idObj is null ? null : ParkId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task UpdateAsync(Park park)
        {
            var query = new Query("parks")
                .AsUpdate(new
                {
                    name = park.Name.Value
                }).Where("id", park.Id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}
