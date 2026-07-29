using Microsoft.AspNetCore.Mvc.Testing;
using Presentation;
using Presentation.Internal.Objects;
using Shared.Dtos.Roles;
using System.Net;
using System.Net.Http.Json;
using Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Controllers
{
    public class RolesControllerTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        private static readonly char[] _chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

        public RolesControllerTest(
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

            var createRequest = GenerateRoleCreateDto();

            var createResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Post,
                "/roles",
                createRequest);

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            var createdEnvelope =
                await createResponse.Content.ReadFromJsonAsync<ResponseEnvelope<RoleDto>>();

            Assert.NotNull(createdEnvelope);
            Assert.NotNull(createdEnvelope.Data);

            var created = createdEnvelope.Data;

            // GET BY ID

            var getResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/roles/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var roleEnvelope =
                await getResponse.Content.ReadFromJsonAsync<ResponseEnvelope<RoleDto>>();

            Assert.NotNull(roleEnvelope);
            Assert.NotNull(roleEnvelope.Data);

            Assert.Equal(created.Id, roleEnvelope.Data.Id);

            // GET ALL

            var listResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                "/roles?limit=100");

            Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

            var rolesEnvelope =
                await listResponse.Content.ReadFromJsonAsync<ResponseEnvelope<RoleSimpleDto[]>>();

            Assert.NotNull(rolesEnvelope);
            Assert.NotNull(rolesEnvelope.Data);

            Assert.Contains(rolesEnvelope.Data, x => x.Id == created.Id);

            // DELETE

            var deleteResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Delete,
                $"/roles/{created.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // GET AFTER DELETE

            var afterDelete = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/roles/{created.Id}");

            Assert.Equal(HttpStatusCode.NotFound, afterDelete.StatusCode);
        }

        private static RoleCreateDto GenerateRoleCreateDto()
        {
            return new(
                new(Random.Shared.GetItems(_chars, 20))
            );
        }
    }
}