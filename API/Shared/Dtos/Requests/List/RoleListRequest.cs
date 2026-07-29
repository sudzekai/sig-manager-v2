namespace Shared.Dtos.Requests.List
{
    public class RoleListRequest : ListRequestBase
    {
        public DateTime CreatedAtStart { get; set; } = default;
        public DateTime CreatedAtEnd { get; set; } = default;
    }
}
