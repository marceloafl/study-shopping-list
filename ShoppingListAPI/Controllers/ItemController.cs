using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        // To do: implementar verificações de retorno do repository
        // To do: melhorar swagger

        [HttpGet]
        public async Task<ActionResult<List<ItemModel>>> GetAllItems()
        {
            List<ItemModel> items = await _itemRepository.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> GetById(int id)
        {
            ItemModel item = await _itemRepository.GetById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> Create([FromBody] ItemModel itemModel)
        {
            ItemModel item = await _itemRepository.Create(itemModel);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemModel>> Update([FromBody] ItemModel itemModel, int id)
        {
            itemModel.Id = id;
            ItemModel item = await _itemRepository.Update(itemModel, id);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool isDeleted = await _itemRepository.Delete(id);
            return Ok(isDeleted);
        }
    }
}
