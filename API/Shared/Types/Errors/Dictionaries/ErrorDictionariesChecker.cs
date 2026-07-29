using Shared.Types.Errors.ApplicationError;
using Shared.Types.Errors.Dictionaries.Entities;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;
using Shared.Utilities.BusinessErrorFactory;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shared.Types.Errors.Dictionaries
{
    public class ErrorDictionariesChecker
    {
        public static void Check()
        {
            EntityErrors.Initialize();

            InternalErrors.Initialize();

            CarObjectErrors.Initialize();
            ParkObjectErrors.Initialize();
            PositionObjectErrors.Initialize();
            ProductObjectErrors.Initialize();
            RightObjectErrors.Initialize();
            RoleObjectErrors.Initialize();
            UserObjectErrors.Initialize();
        }

        public static void PrintAllErrors(TextWriter writer)
        {
            Type[] dictionaries =
            [
                typeof(EntityErrors),
                typeof(InternalErrors),

                typeof(CarObjectErrors),
                typeof(ParkObjectErrors),
                typeof(PositionObjectErrors),
                typeof(ProductObjectErrors),
                typeof(RightObjectErrors),
                typeof(RoleObjectErrors),
                typeof(UserObjectErrors)
            ];

            int count = 0;

            writer.WriteLine($"CODE, KEY");

            foreach (var type in dictionaries)
            {
                var properties = type
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.FieldType == typeof(AppError))
                    .Select(f => (AppError)f.GetValue(null)!);

                foreach (var error in properties.OrderBy(e => e.Code))
                {
                    writer.WriteLine($"{error.Code}, {error.Key}");
                    count++;
                }
                
            }

            writer.WriteLine($"Total error types: {count}");
        }

        public static void PrintAllErrorsWithBusinessMessage(TextWriter writer)
        {
            Type[] dictionaries =
            [
                typeof(EntityErrors),
                typeof(InternalErrors),

                typeof(CarObjectErrors),
                typeof(ParkObjectErrors),
                typeof(PositionObjectErrors),
                typeof(ProductObjectErrors),
                typeof(RightObjectErrors),
                typeof(RoleObjectErrors),
                typeof(UserObjectErrors)
            ];

            const int codeWidth = 10;
            const int keyWidth = 55;
            const int httpWidth = 4;

            writer.WriteLine(
                $"{"INTER CODE",-codeWidth} | {"KEY",-keyWidth} | {"HTTP",-httpWidth} | MESSAGE");
            writer.WriteLine(
                $"{new string('-', codeWidth)}-+-{new string('-', keyWidth)}-+-{new string('-', httpWidth)}-+-{new string('-', 60)}");

            int count = 0;

            foreach (var type in dictionaries)
            {
                var errors = type
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.FieldType == typeof(AppError))
                    .Select(f => (AppError)f.GetValue(null)!)
                    .OrderBy(e => e.Code);

                foreach (var error in errors)
                {
                    var business = BusinessErrorFactory.ToBusinessException(new AppException(error));

                    writer.WriteLine(
                        $"{error.Code,-codeWidth} | " +
                        $"{error.Key,-keyWidth} | " +
                        $"{business.Code,-httpWidth} | " +
                        $"{business.Message}");

                    writer.WriteLine($"{new string('-', codeWidth)}-+-{new string('-', keyWidth)}-+-{new string('-', httpWidth)}-+-{new string('-', 60)}");

                    count++;
                }
            }

            writer.WriteLine();
            writer.WriteLine($"Total error types: {count}");
        }
    }
}
