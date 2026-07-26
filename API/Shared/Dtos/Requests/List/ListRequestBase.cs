namespace Shared.Dtos.Requests.List
{
    public abstract class ListRequestBase
    {
        public string SearchTerm { get; set; } = string.Empty;

        public string OrderBy { get; set; } = string.Empty;

        public string OrderDirection { get; set; } = "asc";

        public int Limit { get; set; } = 10;
     
        public int Offset { get; set; } = 0;
    }
}
