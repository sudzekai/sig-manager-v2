using Microsoft.AspNetCore.Mvc.Testing;
using Presentation;
using Presentation.Internal.Objects;
using Shared.Dtos.Positions;
using System.Net;
using System.Net.Http.Json;
using Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Controllers
{
    public class PositionsControllerTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        private static readonly char[] _chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

        public PositionsControllerTest(
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

            var createRequest = GeneratePositionCreateDto();

            var createResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Post,
                "/positions",
                createRequest);

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            var createdEnvelope =
                await createResponse.Content.ReadFromJsonAsync<ResponseEnvelope<PositionDto>>();

            Assert.NotNull(createdEnvelope);
            Assert.NotNull(createdEnvelope.Data);

            var created = createdEnvelope.Data;

            // GET BY ID

            var getResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/positions/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var positionEnvelope =
                await getResponse.Content.ReadFromJsonAsync<ResponseEnvelope<PositionDto>>();

            Assert.NotNull(positionEnvelope);
            Assert.NotNull(positionEnvelope.Data);

            Assert.Equal(created.Id, positionEnvelope.Data.Id);

            // GET ALL

            var listResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                "/positions?limit=100");

            Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

            var positionsEnvelope =
                await listResponse.Content.ReadFromJsonAsync<ResponseEnvelope<PositionSimpleDto[]>>();

            Assert.NotNull(positionsEnvelope);
            Assert.NotNull(positionsEnvelope.Data);

            Assert.Contains(positionsEnvelope.Data, x => x.Id == created.Id);

            // DELETE

            var deleteResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Delete,
                $"/positions/{created.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // GET AFTER DELETE

            var afterDelete = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/positions/{created.Id}");

            Assert.Equal(HttpStatusCode.NotFound, afterDelete.StatusCode);
        }

        private static PositionCreateDto GeneratePositionCreateDto()
        {
            return new(
                new(Random.Shared.GetItems(_chars, 20)),
                new Random().Next(0, 999)
            );
        }
    }
}