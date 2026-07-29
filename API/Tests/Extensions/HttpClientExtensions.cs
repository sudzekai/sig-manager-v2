using System.Net.Http.Json;
using Xunit.Abstractions;

namespace Tests.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> SendAndLogAsync<T>(
            this HttpClient client,
            ITestOutputHelper output,
            HttpMethod method,
            string url,
            T? body = default)
        {
            var request = new HttpRequestMessage(method, url);

            if (body is not null)
                request.Content = JsonContent.Create(body);

            var response = await client.SendAsync(request);

            await output.LogAsync(request, response, body);

            return response;
        }
    }
}
