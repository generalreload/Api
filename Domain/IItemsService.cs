using Api.Models;

namespace Api.Domain
{
    public interface IItemsService
    {
        public Task<IEnumerable<ItemDto>> GetItems();
        public Task<List<ItemDto>> selectAllItemsAsync(string[] items);
    }
}
