namespace Shared.Dtos.Requests.List
{
    public class UserListRequest : ListRequestBase
    {
        public long RoleId { get; set; } = default;

        public DateTime CreatedAtStart { get; set; } = default;

        public DateTime CreatedAtEnd { get; set; } = default;
    }
}
