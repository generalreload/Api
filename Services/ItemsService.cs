using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Api.Domain;
using Api.Models;


namespace Api.Services
{
    public class ItemsService : IItemsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ItemsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var url = _configuration["ApiSettings:Url"];
            var key = _configuration["ApiSettings:Key"];

            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/api/fetch");
            request.Headers.Add("X-Functions-Key", key);

            var res = await _httpClient.SendAsync(request);
            res.EnsureSuccessStatusCode();

            var content = await res.Content.ReadAsStringAsync();
            var items = JsonSerializer.Deserialize<IEnumerable<ItemDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return items;
        }


        public async Task<List<ItemDto>> selectAllItemsAsync(string[] items)
        {
            var allItems = await GetItems();
            var listOfItems = allItems.Where(item => items.Contains(item.Id.ToString())).ToList();
            
            return listOfItems;
        }
        
    }
}
