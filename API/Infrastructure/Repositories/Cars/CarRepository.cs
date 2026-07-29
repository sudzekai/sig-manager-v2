using Domain.Models.Cars;
using Domain.ValueObjects.Cars;
using Infrastructure.Context;
using MySql.Data.MySqlClient;
using SqlKata;
using System.Data;

namespace Infrastructure.Repositories.Cars
{
    internal class CarRepository(ISigDbContext db) : ICarRepository
    {
        public async Task<CarId> AddAsync(Car car)
        {
            var query = new Query("cars")
                .AsInsert(new
                {
                    id = car.Id.Value,
                    name = car.Name.Value,
                    status = car.Status.Value,
                    controller_model = car.ControllerModel.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();

            return CarId.FromValue((int)((MySqlCommand)command).LastInsertedId);
        }

        public async Task<bool> DeleteAsync(CarId id)
        {
            var query = new Query("cars")
                .AsDelete().Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            var affected = await command.ExecuteNonQueryAsync();

            return affected > 0;
        }

        public async Task<Car?> GetAsync(CarId id)
        {
            var query = new Query("cars")
                .Select("name", "status", "controller_model", "created_at").Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return Car.Restore(
                    id,
                    Name.FromValue(reader.GetString("name")),
                    Status.FromValue(reader.GetString("status")),
                    ControllerModel.FromValue(reader.GetString("controller_model")),
                    reader.GetDateTime("created_at")
                );

            return null;
        }

        public async Task<CarId?> GetIdByIdAsync(CarId id)
        {
            var query = new Query("cars")
                .Select("id").Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return idObj is null ? null : CarId.FromValue(Convert.ToInt64(idObj));

        }

        public async Task<CarId?> GetIdByNameAsync(Name name)
        {
            var query = new Query("cars")
                .Select("id").Where("name", name.Value);

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return idObj is null ? null : CarId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task UpdateAsync(Car car)
        {
            var query = new Query("cars")
                .AsUpdate(new
                {
                    id = car.Id.Value,
                    name = car.Name.Value,
                    status = car.Status.Value,
                    controller_model = car.ControllerModel.Value
                }).Where("id", car.Id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}
