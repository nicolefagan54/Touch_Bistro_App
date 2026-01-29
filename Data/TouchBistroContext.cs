using Microsoft.EntityFrameworkCore;
using Touch_Bistro_App.Models;

namespace Touch_Bistro_App.Data
{
    public class TouchBistroContext : DbContext
    {
        public TouchBistroContext(DbContextOptions<TouchBistroContext> options)
            : base(options)
        {
        }

        public DbSet<Table> Tables { get; set; } = null!;
        public DbSet<MenuItem> Menu { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
    }
}
