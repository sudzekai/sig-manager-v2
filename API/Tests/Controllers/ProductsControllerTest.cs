using Microsoft.AspNetCore.Mvc.Testing;
using Presentation;
using Presentation.Internal.Objects;
using Shared.Dtos.Products;
using System.Net;
using System.Net.Http.Json;
using Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Controllers
{
    public class ProductsControllerTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        private static readonly char[] _chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

        public ProductsControllerTest(
            WebApplicationFactory<Program> factory,
            ITestOutputHelper output)
        {
            _client = factory.CreateClient();
            _output = output;
        }

        [Fact]
        public async Task CRUD_Should_Work()
        {
            // CREATE

            var createRequest = GenerateProductCreateDto();

            var createResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Post,
                "/products",
                createRequest);

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            var createdEnvelope =
                await createResponse.Content.ReadFromJsonAsync<ResponseEnvelope<ProductDto>>();

            Assert.NotNull(createdEnvelope);
            Assert.NotNull(createdEnvelope.Data);

            var created = createdEnvelope.Data;

            // GET BY ID

            var getResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/products/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var productEnvelope =
                await getResponse.Content.ReadFromJsonAsync<ResponseEnvelope<ProductDto>>();

            Assert.NotNull(productEnvelope);
            Assert.NotNull(productEnvelope.Data);

            Assert.Equal(created.Id, productEnvelope.Data.Id);

            // GET ALL

            var listResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                "/products?limit=100");

            Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

            var productsEnvelope =
                await listResponse.Content.ReadFromJsonAsync<ResponseEnvelope<ProductSimpleDto[]>>();

            Assert.NotNull(productsEnvelope);
            Assert.NotNull(productsEnvelope.Data);

            Assert.Contains(productsEnvelope.Data, x => x.Id == created.Id);

            // DELETE

            var deleteResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Delete,
                $"/products/{created.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // GET AFTER DELETE

            var afterDelete = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/products/{created.Id}");

            Assert.Equal(HttpStatusCode.NotFound, afterDelete.StatusCode);
        }

        private static ProductCreateDto GenerateProductCreateDto()
        {
            return new(
                new(Random.Shared.GetItems(_chars, 20)),
                new Random().Next(1, 9999)
            );
        }
    }
}