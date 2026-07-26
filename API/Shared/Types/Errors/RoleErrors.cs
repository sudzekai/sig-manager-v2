namespace Shared.Types.Errors
{
    public static class RoleErrors
    {
        // default = 0
        public static readonly ErrorCode NotFound = ErrorCode.Create($"ROLE.NOT_FOUND", 3_00_01);

        // id = 1
        public static readonly ErrorCode IdIsInvalid = ErrorCode.Create($"ROLE.ID.INVALID", 3_01_01);
    }
}
