using Domain.ValueObjects.Products;
using Infrastructure.Context;
using Shared.Dtos.Products;
using Shared.Dtos.Requests.List;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Queries.Products
{
    internal class ProductsQuery(ISigDbContext db) : IProductsQuery
    {
        public async Task<ProductSimpleDto[]> GetAllAsync(ProductListRequest request)
        {
            var query = new Query("products").
                Select("id", "name");

            if (request.CreatedAtStart != default)
                query.Where("created_at", ">=", request.CreatedAtStart);

            if (request.CreatedAtEnd != default)
                query.Where("created_at", "<=", request.CreatedAtEnd);

            if (request.PriceStart != default)
                query.Where("price", ">=", request.PriceStart);

            if (request.PriceEnd != default)
                query.Where("price", "<=", request.PriceEnd);

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
                    "price" => "price",
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

            List<ProductSimpleDto> result = [];

            while (await reader.ReadAsync())
                result.Add(new(
                    reader.GetInt64(idOrdinal),
                    reader.GetString(nameOrdinal)
                ));

            return [.. result];
        }

        public async Task<ProductDto?> GetByIdAsync(ProductId id)
        {
            var query = new Query("products")
                .Select("name", "price")
                .Where("id", id.Value);

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new(
                    id.Value,
                    reader.GetString("name"),
                    reader.GetDecimal("price")
                );

            return null;
        }
    }
}
