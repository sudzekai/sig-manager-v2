using Microsoft.AspNetCore.Mvc.Testing;
using Presentation;
using Presentation.Internal.Objects;
using Shared.Dtos.Parks;
using System.Net;
using System.Net.Http.Json;
using Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Controllers
{
    public class ParksControllerTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        private static readonly char[] _chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

        public ParksControllerTest(
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

            var createRequest = GenerateParkCreateDto();

            var createResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Post,
                "/parks",
                createRequest);

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            var createdEnvelope =
                await createResponse.Content.ReadFromJsonAsync<ResponseEnvelope<ParkDto>>();

            Assert.NotNull(createdEnvelope);
            Assert.NotNull(createdEnvelope.Data);

            var created = createdEnvelope.Data;

            // GET BY ID

            var getResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/parks/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var parkEnvelope =
                await getResponse.Content.ReadFromJsonAsync<ResponseEnvelope<ParkDto>>();

            Assert.NotNull(parkEnvelope);
            Assert.NotNull(parkEnvelope.Data);

            Assert.Equal(created.Id, parkEnvelope.Data.Id);

            // GET ALL

            var listResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                "/parks?limit=100");

            Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

            var parksEnvelope =
                await listResponse.Content.ReadFromJsonAsync<ResponseEnvelope<ParkSimpleDto[]>>();

            Assert.NotNull(parksEnvelope);
            Assert.NotNull(parksEnvelope.Data);

            Assert.Contains(parksEnvelope.Data, x => x.Id == created.Id);

            // DELETE

            var deleteResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Delete,
                $"/parks/{created.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // GET AFTER DELETE

            var afterDelete = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/parks/{created.Id}");

            Assert.Equal(HttpStatusCode.NotFound, afterDelete.StatusCode);
        }

        private static ParkCreateDto GenerateParkCreateDto()
        {
            return new(
                new(Random.Shared.GetItems(_chars, 20))
            );
        }
    }
}