using Microsoft.AspNetCore.Mvc.Testing;
using Presentation;
using Presentation.Internal.Objects;
using Shared.Dtos.Rights;
using System.Net;
using System.Net.Http.Json;
using Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Controllers
{
    public class RightsControllerTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        private static readonly char[] _chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

        public RightsControllerTest(
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

            var createRequest = GenerateRightCreateDto();

            var createResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Post,
                "/rights",
                createRequest);

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            var createdEnvelope =
                await createResponse.Content.ReadFromJsonAsync<ResponseEnvelope<RightDto>>();

            Assert.NotNull(createdEnvelope);
            Assert.NotNull(createdEnvelope.Data);

            var created = createdEnvelope.Data;

            // GET BY ID

            var getResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/rights/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var rightEnvelope =
                await getResponse.Content.ReadFromJsonAsync<ResponseEnvelope<RightDto>>();

            Assert.NotNull(rightEnvelope);
            Assert.NotNull(rightEnvelope.Data);

            Assert.Equal(created.Id, rightEnvelope.Data.Id);

            // GET ALL

            var listResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                "/rights?limit=100");

            Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

            var rightsEnvelope =
                await listResponse.Content.ReadFromJsonAsync<ResponseEnvelope<RightSimpleDto[]>>();

            Assert.NotNull(rightsEnvelope);
            Assert.NotNull(rightsEnvelope.Data);

            Assert.Contains(rightsEnvelope.Data, x => x.Id == created.Id);

            // DELETE

            var deleteResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Delete,
                $"/rights/{created.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // GET AFTER DELETE

            var afterDelete = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/rights/{created.Id}");

            Assert.Equal(HttpStatusCode.NotFound, afterDelete.StatusCode);
        }

        private static RightCreateDto GenerateRightCreateDto()
        {
            return new(
                new(Random.Shared.GetItems(_chars, 20))
            );
        }
    }
}