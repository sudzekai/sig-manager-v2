namespace Shared.Dtos.Requests.List
{
    public class RightListRequest : ListRequestBase
    {
        public DateTime CreatedAtStart { get; set; } = default;
        public DateTime CreatedAtEnd { get; set; } = default;
    }
}
