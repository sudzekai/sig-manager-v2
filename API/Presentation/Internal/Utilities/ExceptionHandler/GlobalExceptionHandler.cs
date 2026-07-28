using Shared.Types.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Internal.Utilities.ExceptionHandler
{
    internal static class GlobalExceptionHandler
    {
        public static void Register()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        }

        private static void OnUnhandledException(object? sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
                LogException(ex);

            LogInfo("Приложение остановлено");
            Environment.Exit(-1);
        }

        private static void LogException(Exception exception)
        {
            if (exception is AggregateException aggregate)
            {
                LogCritical("Обнаружено несколько ошибок:");

                foreach (var inner in aggregate.Flatten().InnerExceptions)
                    LogSingleException(inner);

                return;
            }

            LogSingleException(exception);
        }

        private static void LogSingleException(Exception exception)
        {
            var appException = GetAppException(exception);

            if (appException is not null)
            {
                LogCritical(appException.ToString());
                return;
            }

            LogCritical($"{exception.GetType().Name}: {exception.Message}");
        }

        private static AppException? GetAppException(Exception? exception)
        {
            while (exception is not null)
            {
                if (exception is AppException appException)
                    return appException;

                exception = exception.InnerException;
            }

            return null;
        }

        private static void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            LogCritical($"{e.Exception.GetType().ToString().Split(".").Last()}: {e.Exception.Message}");
            e.SetObserved();

            LogInfo("Приложение остановлено");
            Environment.Exit(-1);
        }

        private static void LogCritical(string message)
        {
            Console.Write($"{DateTime.Now:[HH:mm:ss]}");

            Console.Write($" | ");

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.Write($"{"Critical",-11}");
            Console.ResetColor();

            Console.Write($" | {message}\n");
        }

        private static void LogInfo(string message)
        {
            Console.Write($"{DateTime.Now:[HH:mm:ss]}");

            Console.Write($" | ");

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write($"{"Information",-11}");
            Console.ResetColor();

            Console.Write($" | {message}\n");
        }
    }
}