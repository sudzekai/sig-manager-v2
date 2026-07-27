using Microsoft.Extensions.Configuration;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Exceptions;

namespace Presentation.Internal.Extensions
{
    internal static class ConfigurationExtension
    {
        public static string GetString(this ConfigurationManager configuration, string key)
        {
            var value = configuration[key]
                ?? throw new AppException(InternalErrors.ConfigVariableNotFound, $"variable key: {key}");

            return value;
        }
    }
}
