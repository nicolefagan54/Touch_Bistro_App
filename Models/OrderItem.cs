namespace Touch_Bistro_App.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Total => MenuItem != null ? MenuItem.Price * Quantity : 0;
    }
}
