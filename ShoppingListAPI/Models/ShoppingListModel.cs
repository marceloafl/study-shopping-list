using System.Collections.ObjectModel;

namespace ShoppingListAPI.Models
{
    public class ShoppingListModel
    {
        public ShoppingListModel()
        {
            Items = new Collection<ItemModel>();
        }

        public int Id { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? Date { get; set; }
        public virtual ICollection<ItemModel>? Items { get; set; }
    }
}
