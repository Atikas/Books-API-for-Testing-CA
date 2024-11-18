namespace BooksApi.DTOs
{
    public class BookPriceApiResult
    {
        public string ISBN { get; set; }
        public string Shop { get; set; }
        public string Url { get; set; }
        public string CoverType { get; set; }
        public double Price { get; set; }
    }
}
