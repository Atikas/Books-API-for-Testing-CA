using BooksApi.DTOs;

namespace BooksApi.Services
{
    public interface IBookPriceExternalClient
    {
        Task<double> GetPrice(string isbn, string coverType);
    }
    public class BookPriceExternalClient: IBookPriceExternalClient
    {
        private readonly ILogger<BookPriceExternalClient> _logger;
        private readonly HttpClient _client;

        public BookPriceExternalClient(ILogger<BookPriceExternalClient> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<double> GetPrice(string isbn, string coverType)
        {
            var response = await _client.GetFromJsonAsync<List<BookPriceApiResult>>($"Books/Price?isbn={isbn}");
            return response!.FirstOrDefault(x => x.CoverType == coverType)?.Price ?? 0;

        }
    }
}
