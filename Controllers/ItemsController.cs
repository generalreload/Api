using Api.Domain;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {

        private readonly IItemsService _itemsService;
        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Get()
        {
            // TODO: Return items fetched from external API
            //return Array.Empty<ItemDto>();

            var items = await _itemsService.GetItems();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Post([FromForm]string[] items)
        {
            // TODO: Return a list of the items selected based on the "items" array posted from the frontend
            //return Array.Empty<ItemDto>();
            
            var listOfItems = await _itemsService.selectAllItemsAsync(items);
            return Ok(listOfItems);
        }
    }
}