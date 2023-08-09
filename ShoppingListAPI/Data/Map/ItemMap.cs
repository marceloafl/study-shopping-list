using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingListAPI.Enums;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Data.Map
{
    public class ItemMap : IEntityTypeConfiguration<ItemModel>
    {
        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Quantity)
                .IsRequired();

            builder
                .Property(x => x.Brand)
                .HasMaxLength(255);

            builder
                .Property(x => x.Comments)
                .HasMaxLength(1000);

            builder
                .Property(x => x.Status)
                .HasDefaultValue(Status.Pending)
                .HasConversion<string>();

            builder
                .Property(x => x.ShoppingListId)
                .IsRequired();

            builder
                .HasOne(x => x.ShoppingList)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.ShoppingListId);
        }
    }
}
