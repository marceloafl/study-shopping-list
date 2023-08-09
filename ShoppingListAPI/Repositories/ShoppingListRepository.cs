using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Context;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories
{
    public interface IShoppingListRepository
    {
        Task<List<ShoppingListModel>> GetAllLists();
        Task<ShoppingListModel> GetById(int id);
        Task<ShoppingListModel> Create(ShoppingListModel shoppingListModel);
        Task<ShoppingListModel> Update(ShoppingListModel shoppingListModel, int id);
        Task<bool> Delete(int id);
    }

    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ShoppingListAPIContext _context;

        public ShoppingListRepository(ShoppingListAPIContext shoppingListAPIContext)
        {
            _context = shoppingListAPIContext;
        }
        public async Task<List<ShoppingListModel>> GetAllLists()
        {
            return await _context.ShoppingLists.ToListAsync();            
        }

        public async Task<ShoppingListModel> GetById(int id)
        {
            return await _context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ShoppingListModel> Create(ShoppingListModel shoppingListModel)
        {
            await _context.ShoppingLists.AddAsync(shoppingListModel);
            await _context.SaveChangesAsync();
            return shoppingListModel;
        }

        public async Task<ShoppingListModel> Update(ShoppingListModel shoppingListModel, int id)
        {
            ShoppingListModel shoppingListById = await GetById(id);

            // To do: implementar autommaper
            shoppingListById.TotalPrice = shoppingListModel.TotalPrice;
            shoppingListById.Date = shoppingListModel.Date;

            _context.Update(shoppingListById);
            await _context.SaveChangesAsync();

            return shoppingListById;

        }

        public async Task<bool> Delete(int id)
        {
            ShoppingListModel shoppingListById = await GetById(id);
            _context.ShoppingLists.Remove(shoppingListById);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
