using ShoppingListAPI.Enums;

namespace ShoppingListAPI.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public MetricUnit? MetricUnit { get; set; }
        public string? Brand { get; set; }
        public string? Comments { get; set; }
        public float? Price { get; set; }
        public Status Status { get; set; }
        public int ShoppingListId { get; set; }
        public virtual ShoppingListModel? ShoppingList { get; set; }
    }
}
