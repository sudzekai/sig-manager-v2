using Domain.Models.Products;
using Domain.ValueObjects.Products;
using Infrastructure.Context;
using MySql.Data.MySqlClient;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Repositories.Products
{
    internal class ProductRepository(ISigDbContext db) : IProductRepository
    {
        public async Task<ProductId> AddAsync(Product product)
        {
            var query = new Query("cars")
                .AsInsert(new
                {
                    name = product.Name.Value,
                    price = product.Price.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();

            return ProductId.FromValue((int)((MySqlCommand)command).LastInsertedId);
        }

        public async Task<bool> DeleteAsync(ProductId id)
        {
            var query = new Query("products")
                .AsDelete().Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            var affected = await command.ExecuteNonQueryAsync();

            return affected > 0;
        }

        public async Task<Product?> GetAsync(ProductId id)
        {
            var query = new Query("products")
                .Select("name", "price").Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return Product.Restore(
                    id,
                    Name.FromValue(reader.GetString("name")),
                    Price.FromValue(reader.GetDecimal("price"))
                );

            return null;
        }

        public async Task<ProductId?> GetIdByNameAsync(Name name)
        {
            var query = new Query("products")
                .Select("id").Where("name", name.Value);

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return idObj is null ? null : ProductId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task UpdateAsync(Product product)
        {
            var query = new Query("products")
                .AsUpdate(new
                {
                    name = product.Name.Value,
                    price = product.Price.Value
                }).Where("id", product.Id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}
