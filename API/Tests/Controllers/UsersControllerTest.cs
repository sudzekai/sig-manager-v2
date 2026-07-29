using Microsoft.AspNetCore.Mvc.Testing;
using Presentation;
using Presentation.Internal.Objects;
using Shared.Dtos.Users;
using System.Net;
using System.Net.Http.Json;
using Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Controllers
{
    public class UsersControllerTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        private static readonly char[] _chars =
            "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ ".ToCharArray();

        private static readonly char[] _nums =
            "0123456789".ToCharArray();

        private static readonly char[] _richChars =
            "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ0123456789_!".ToCharArray();

        public UsersControllerTest(
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

            var createRequest = GenerateUserCreateDto();

            var createResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Post,
                "/users",
                createRequest);

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            var createdEnvelope =
                await createResponse.Content.ReadFromJsonAsync<ResponseEnvelope<UserDto>>();

            Assert.NotNull(createdEnvelope);
            Assert.NotNull(createdEnvelope.Data);

            var created = createdEnvelope.Data;

            // GET BY ID

            var getResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/users/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var userEnvelope =
                await getResponse.Content.ReadFromJsonAsync<ResponseEnvelope<UserDto>>();

            Assert.NotNull(userEnvelope);
            Assert.NotNull(userEnvelope.Data);
            Assert.Equal(created.Id, userEnvelope.Data.Id);

            // GET ALL

            var listResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                "/users?limit=100");

            Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

            var usersEnvelope =
                await listResponse.Content.ReadFromJsonAsync<ResponseEnvelope<UserSimpleDto[]>>();

            Assert.NotNull(usersEnvelope);
            Assert.NotNull(usersEnvelope.Data);
            Assert.Contains(usersEnvelope.Data, x => x.Id == created.Id);

            // UPDATE INFO

            var updateRequest = new UserInfoUpdateDto(
                new(Random.Shared.GetItems(_richChars, 20)),
                $"{new(Random.Shared.GetItems(_richChars, 20))}@{new(Random.Shared.GetItems(_richChars, 4))}.{new(Random.Shared.GetItems(_richChars, 4))}",
                $"{new(Random.Shared.GetItems(_chars, 20))} {new(Random.Shared.GetItems(_chars, 20))} {new(Random.Shared.GetItems(_chars, 20))}",
                $"+79{new(Random.Shared.GetItems(_nums, 9))}");

            var updateResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Put,
                $"/users/{created.Id}",
                updateRequest);

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

            var updatedEnvelope =
                await updateResponse.Content.ReadFromJsonAsync<ResponseEnvelope<UserDto>>();

            Assert.NotNull(updatedEnvelope);
            
            var updated = updatedEnvelope.Data;
            Assert.NotNull(updated);

            Assert.Equal(updateRequest.Username, updated.Username);
            Assert.Equal(updateRequest.Email, updated.Email);
            Assert.Equal(updateRequest.FullName, updated.FullName);
            Assert.Equal(updateRequest.PhoneNumber, updated.PhoneNumber);

            // UPDATE ROLE

            var roleResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Patch,
                $"/users/{created.Id}/role",
                new UserRoleUpdateDto(1));

            Assert.Equal(HttpStatusCode.OK, roleResponse.StatusCode);

            // UPDATE PASSWORD

            var passwordResponse = await _client.SendAndLogAsync(
                _output,
                HttpMethod.Patch,
                $"/users/{created.Id}/password",
                new UserPasswordUpdateDto(
                    new(Random.Shared.GetItems(_richChars, 20))));

            Assert.Equal(HttpStatusCode.NoContent, passwordResponse.StatusCode);

            // DELETE

            var deleteResponse = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Delete,
                $"/users/{created.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // GET AFTER DELETE

            var afterDelete = await _client.SendAndLogAsync<object>(
                _output,
                HttpMethod.Get,
                $"/users/{created.Id}");

            Assert.Equal(HttpStatusCode.NotFound, afterDelete.StatusCode);
        }
        private static UserCreateDto GenerateUserCreateDto()
        {
            return new(
                new(Random.Shared.GetItems(_richChars, 20)),
                $"{new(Random.Shared.GetItems(_richChars, 20))}@{new(Random.Shared.GetItems(_richChars, 4))}.{new(Random.Shared.GetItems(_richChars, 4))}",
                $"{new(Random.Shared.GetItems(_chars, 20))} {new(Random.Shared.GetItems(_chars, 20))} {new(Random.Shared.GetItems(_chars, 20))}",
                $"+79{new(Random.Shared.GetItems(_nums, 9))}",
                new(Random.Shared.GetItems(_richChars, 20))
            );
        }
    }
}