namespace Shared.Dtos.Requests.List
{
    public class ProductListRequest : ListRequestBase
    {
        public DateTime CreatedAtStart { get; set; } = default;
        public DateTime CreatedAtEnd { get; set; } = default;

        public decimal PriceStart { get; set; } = default;
        public decimal PriceEnd { get; set; } = default;
    }
}
