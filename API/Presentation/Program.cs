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
using Shared.Types.Errors.Dictionaries;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            GlobalExceptionHandler.Register();

            ErrorDictionariesChecker.Check();
            ErrorDictionariesChecker.PrintAllErrors(Console.Out);

            var builder = WebApplication.CreateBuilder(args);

            using (var loggerFactory = LoggerFactory.Create(log =>
            {
                log.AddConsole(o =>
                {
                    o.FormatterName = "custom";
                });

                log.AddConsoleFormatter<LogFormatter, ConsoleFormatterOptions>();
            }))
            {
                var logger = loggerFactory.CreateLogger("DI");

                // infrastructure
                var connectionString = builder.Configuration.GetString("ConnectionStrings:Default");

                builder.Services.AddInfrastructureServices(connectionString, logger);

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
                builder.Services.AddApplicationServices(logger);

                // presentation
                builder.Services.AddFilters();
                builder.Services.AddControllers(o =>
                {
                    o.Filters.Add<ExceptionsFilter>();
                    o.Filters.Add<ResultFilter>();
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
            }

            builder.Services.AddOpenApi();

            WebApplication? app = null;

            app = builder.Build();

            if (app is null)
                return;

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
