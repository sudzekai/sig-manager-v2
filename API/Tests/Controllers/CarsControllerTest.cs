using Microsoft.AspNetCore.Mvc.Testing;
using Presentation;
using Presentation.Internal.Objects;
using Shared.Dtos.Cars;
using System.Net;
using System.Net.Http.Json;
using Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Controllers
{
    public class CarsControllerTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        private static readonly char[] _chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        private static readonly char[] _richChars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        public CarsControllerTest(
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

            var createRequest = GenerateCarCreateDto();

            var createResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Post,
                "/cars",
                createRequest);

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            var createEnvelope =
                await createResponse.Content.ReadFromJsonAsync<ResponseEnvelope<CarDto>>();

            Assert.NotNull(createEnvelope);
            Assert.NotNull(createEnvelope.Data);

            var created = createEnvelope.Data;

            // GET BY ID

            var getResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/cars/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var getEnvelope =
                await getResponse.Content.ReadFromJsonAsync<ResponseEnvelope<CarDto>>();

            Assert.NotNull(getEnvelope);
            Assert.NotNull(getEnvelope.Data);

            Assert.Equal(created.Id, getEnvelope.Data.Id);

            // GET ALL

            var listResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                "/cars?limit=100");

            Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

            var listEnvelope =
                await listResponse.Content.ReadFromJsonAsync<ResponseEnvelope<CarSimpleDto[]>>();

            Assert.NotNull(listEnvelope);
            Assert.NotNull(listEnvelope.Data);

            Assert.Contains(listEnvelope.Data, x => x.Id == created.Id);

            // DELETE

            var deleteResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Delete,
                $"/cars/{created.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // GET AFTER DELETE

            var afterDelete = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/cars/{created.Id}");

            Assert.Equal(HttpStatusCode.NotFound, afterDelete.StatusCode);
        }

        private static CarCreateDto GenerateCarCreateDto()
        {
            return new(
                new Random().Next(1, 1000),
                new(Random.Shared.GetItems(_chars, 17)),
                new(Random.Shared.GetItems(_richChars, 49))
            );
        }
    }
}