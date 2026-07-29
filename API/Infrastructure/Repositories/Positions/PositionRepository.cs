using Domain.Models.Positions;
using Domain.ValueObjects.Positions;
using Infrastructure.Context;
using MySql.Data.MySqlClient;
using SqlKata;
using System.Data;

namespace Infrastructure.Repositories.Positions
{
    internal class PositionRepository(ISigDbContext db) : IPositionRepository
    {
        public async Task<PositionId> AddAsync(Position position)
        {
            var query = new Query("cars")
                .AsInsert(new
                {
                    name = position.Name.Value,
                    price_per_hour = position.PricePerHour.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();

            return PositionId.FromValue((int)((MySqlCommand)command).LastInsertedId);
        }

        public async Task<bool> DeleteAsync(PositionId id)
        {
            var query = new Query("positions")
                .AsDelete().Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            var affected = await command.ExecuteNonQueryAsync();

            return affected > 0;
        }

        public async Task<Position?> GetAsync(PositionId id)
        {
            var query = new Query("positions")
                .Select("name", "price_per_hour").Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return Position.Restore(
                    id,
                    Name.FromValue(reader.GetString("name")),
                    PricePerHour.FromValue(reader.GetDecimal("price_per_hour"))
                );

            return null;
        }

        public async Task<PositionId?> GetIdByNameAsync(Name name)
        {
            var query = new Query("positions")
                .Select("id").Where("name", name.Value);

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return idObj is null ? null : PositionId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task UpdateAsync(Position position)
        {
            var query = new Query("positions")
                .AsUpdate(new
                {
                    name = position.Name.Value,
                    price_per_hour = position.PricePerHour.Value
                }).Where("id", position.Id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}
