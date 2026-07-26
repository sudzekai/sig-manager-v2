using Microsoft.Extensions.Configuration;
using Shared.Types.Errors;
using Shared.Types.Exceptions;

namespace Presentation.Internal.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetString(this ConfigurationManager configuration, string key)
        {
            var value = configuration[key]
                ?? throw new AppException(InternalErrors.ConfigVariableNotFound);

            return value;
        }
    }
}
