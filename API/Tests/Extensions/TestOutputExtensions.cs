namespace Tests.Extensions
{
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using Xunit.Abstractions;

    public static class TestOutputExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static async Task LogAsync<T>(
            this ITestOutputHelper output,
            HttpRequestMessage request,
            HttpResponseMessage response,
            T? body = default)
        {
            output.WriteLine($"METHOD: {request.Method}");
            output.WriteLine($"URL:    {request.RequestUri}");

            output.WriteLine("BODY:");

            if (body is null)
            {
                output.WriteLine("<empty>");
            }
            else
            {
                output.WriteLine(JsonSerializer.Serialize(body, _jsonOptions));
            }

            output.WriteLine($"STATUS: {(int)response.StatusCode} {response.StatusCode}");

            output.WriteLine("RESPONSE:");

            if (response.Content is null)
            {
                output.WriteLine("<empty>");
            }
            else
            {
                output.WriteLine(await PrettyJson(response.Content));
            }

            output.WriteLine(new string('-', 80));
        }

        private static async Task<string> PrettyJson(HttpContent content)
        {
            var text = await content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(text))
                return "<empty>";

            try
            {
                using var json = JsonDocument.Parse(text);
                return JsonSerializer.Serialize(json, _jsonOptions);
            }
            catch
            {
                return text;
            }
        }
    }
}
