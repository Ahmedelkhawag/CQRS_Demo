using CQRS_Library.CQRS.Commands;
using CQRS_Library.CQRS.Queries;
using CQRS_Library.Data.Models;
using CQRS_Library.Repos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IMediator _mediator;

        public ItemsController(IItemsRepository itemsRepository, IMediator mediator)
        {
            _itemsRepository = itemsRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _mediator.Send(new GetAllItems());
            return Ok(items);
        }
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item cannot be null");
            }
           var Item =  await _mediator.Send(new AddItemCommand(item));
            return Ok(Item);
        }
    }
}
