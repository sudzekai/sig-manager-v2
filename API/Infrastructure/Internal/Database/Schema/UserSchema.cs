namespace Infrastructure.Internal.Database.Schema
{
    internal sealed class UserSchema
    {
        public const string TableName = "users";

        public const string Id = "id";
        public const string RoleId = "role_id";
        public const string Username = "username";
        public const string Email = "email";
        public const string PasswordHash = "password_hash";
        public const string FullName = "full_name";
        public const string PhoneNumber = "phone_number";
        public const string PhoneNumberLastFour = "phone_number_last_four";
        public const string CreatedAt = "created_at";
    }
}
