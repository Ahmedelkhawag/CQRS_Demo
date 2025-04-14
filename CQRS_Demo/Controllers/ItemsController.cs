using CQRS_Library.Data.Models;
using CQRS_Library.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemsController(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemsRepository.GetAllItems();
            return Ok(items);
        }
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item cannot be null");
            }
            await _itemsRepository.AddItem(item);
            return CreatedAtAction(nameof(GetAllItems), new { id = item.Id }, item);
        }
    }
}
