using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        // To do: implementar verificações de retorno do repository
        // To do: melhorar swagger

        [HttpGet]
        public async Task<ActionResult<List<ShoppingListModel>>> GetAllLists()
        {
            List<ShoppingListModel> lists = await _shoppingListRepository.GetAllLists();
            return Ok(lists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListModel>> GetById(int id)
        {
            ShoppingListModel list = await _shoppingListRepository.GetById(id);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingListModel>> Create([FromBody] ShoppingListModel shoppingListModel)
        {
            ShoppingListModel list = await _shoppingListRepository.Create(shoppingListModel);
            return Ok(list);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ShoppingListModel>> Update([FromBody] ShoppingListModel shoppingListModel, int id)
        {
            shoppingListModel.Id = id;
            ShoppingListModel list = await _shoppingListRepository.Update(shoppingListModel, id);
            return Ok(list);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool isDeleted = await _shoppingListRepository.Delete(id);
            return Ok(isDeleted);
        }
    }
}
