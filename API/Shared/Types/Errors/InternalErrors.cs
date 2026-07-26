namespace Shared.Types.Errors
{
    public static class InternalErrors
    {
        public static readonly ErrorCode ConfigVariableNotFound = ErrorCode.Create($"INTERNAL.CONFIGURATION_VARIABLE.NOT_FOUND", 1000);
    }
}
