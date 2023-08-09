using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Context;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> GetAllItems();
        Task<ItemModel> GetById(int id);
        Task<ItemModel> Create(ItemModel itemModel);
        Task<ItemModel> Update(ItemModel itemModel, int id);
        Task<bool> Delete(int id);
    }

    public class ItemRepository : IItemRepository
    {
        private readonly ShoppingListAPIContext _context;

        public ItemRepository(ShoppingListAPIContext shoppingListAPIContext)
        {
            _context = shoppingListAPIContext;
        }

        public async Task<List<ItemModel>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<ItemModel> GetById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ItemModel> Create(ItemModel itemModel)
        {
            await _context.Items.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<ItemModel> Update(ItemModel itemModel, int id)
        {
            // To do: implementar automapper
            ItemModel itemPorId = await GetById(id);
            itemPorId.Name = itemModel.Name;
            itemModel.Quantity = itemModel.Quantity;
            itemPorId.MetricUnit = itemModel.MetricUnit;
            itemPorId.Brand = itemModel.Brand;
            itemPorId.Comments = itemModel.Comments;
            itemPorId.Price = itemModel.Price;
            itemPorId.Status = itemModel.Status;

            _context.Items.Update(itemPorId);
            await _context.SaveChangesAsync();

            return itemPorId;
        }

        public async Task<bool> Delete(int id)
        {
            ItemModel itemPorId = await GetById(id);
            _context.Items.Remove(itemPorId);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
