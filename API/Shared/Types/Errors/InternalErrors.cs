namespace Shared.Types.Errors
{
    public static class InternalErrors
    {
        public static readonly ErrorCode ConfigVariableNotFound = ErrorCode.Create($"INTERNAL.CONFIGURATION_VARIABLE.NOT_FOUND", 1_00_01);
        public static readonly ErrorCode ServiceNotFound = ErrorCode.Create($"INTERNAL.SERVICE.NOT_FOUND", 1_00_02);
    }
}
