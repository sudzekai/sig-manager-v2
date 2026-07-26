using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Presentation.DI;
using Presentation.Filters;
using Presentation.Internal.Extensions;
using Presentation.Internal.Utilities.ExceptionHandler;
using Presentation.Internal.Utilities.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            GlobalExceptionHandler.Register();

            var builder = WebApplication.CreateBuilder(args);

            // infrastructure
            var connectionString = builder.Configuration.GetString("ConnectionStrings:Default");

            builder.Services.AddInfrastructureServices(connectionString);

            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole(options =>
                {
                    options.FormatterName = "custom";
                });

                logging.AddConsoleFormatter<LogFormatter, ConsoleFormatterOptions>();

                logging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.None);
            });

            // app
            builder.Services.AddApplicationServices();

            // presentation
            builder.Services.AddFilters();
            builder.Services.AddControllers(o =>
            {
                o.Filters.Add<ExceptionsFilter>();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseAppLifetimeLogging();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            var pathBase = builder.Configuration.GetString("UrlRootPath");

            app.UsePathBase(pathBase);

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();

            app.MapControllers();

            await app.StartAsync();

            await LogStartAsync(builder, app);

            await app.WaitForShutdownAsync();
        }

        private static async Task LogStartAsync(WebApplicationBuilder builder, WebApplication app)
        {
            var logger = app.Services.GetRequiredService<ILogger<Program>>();

            string version = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion?.Split('+')[0] ?? "Unknown";

            logger.LogInformation("Версия: {version}", version);

            logger.LogInformation("Среда: {environment}", builder.Environment.EnvironmentName);

            logger.LogInformation("Сервер прослушивает: {host}", string.Join(", ", app.Urls));

            logger.LogInformation("Базовый путь API: {pathBase}", builder.Configuration.GetString("UrlRootPath"));
        }
    }
}
