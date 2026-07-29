namespace Shared.Dtos.Requests.List
{
    public class CarListRequest : ListRequestBase
    {
        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAtStart { get; set; } = default;
        public DateTime CreatedAtEnd { get; set; } = default;
    }
}
