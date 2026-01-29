using System;
using System.Collections.Generic;
using System.Linq;

namespace Touch_Bistro_App.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public bool IsPaid { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal TotalAmount => Items.Sum(i => i.Total);
    }
}
