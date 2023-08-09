using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Data.Map
{
    public class ShoppingListMap : IEntityTypeConfiguration<ShoppingListModel>
    {
        public void Configure(EntityTypeBuilder<ShoppingListModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Items)
                .WithOne(x => x.ShoppingList)
                .HasForeignKey(x => x.ShoppingListId);
        }
    }
}
