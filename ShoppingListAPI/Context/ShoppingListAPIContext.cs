using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Data.Map;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Context
{
    public class ShoppingListAPIContext : DbContext
    {
        public ShoppingListAPIContext(DbContextOptions<ShoppingListAPIContext> options) : base(options)
        {}

        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ShoppingListModel> ShoppingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
