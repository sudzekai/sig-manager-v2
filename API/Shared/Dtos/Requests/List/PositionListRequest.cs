namespace Shared.Dtos.Requests.List
{
    public class PositionListRequest : ListRequestBase
    {
        public decimal PricePerHourStart { get; set; } = default;
        public decimal PricePerHourEnd { get; set; } = default;
    }
}
