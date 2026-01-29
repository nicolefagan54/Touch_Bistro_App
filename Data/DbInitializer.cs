using System.Linq;
using Touch_Bistro_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Touch_Bistro_App.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TouchBistroContext context)
        {
            context.Database.Migrate();

            if (context.Tables.Any())
            {
                return;   // DB has been seeded
            }

            var tables = new Table[]
            {
                new Table{Number=1, Status="Free"},
                new Table{Number=2, Status="Free"},
                new Table{Number=3, Status="Free"},
                new Table{Number=4, Status="Free"},
                new Table{Number=5, Status="Free"},
                new Table{Number=6, Status="Free"},
                new Table{Number=7, Status="Free"},
                new Table{Number=8, Status="Free"},
                new Table{Number=9, Status="Free"},
                new Table{Number=10, Status="Free"},
            };
            context.Tables.AddRange(tables);

            var menu = new MenuItem[]
            {
                new MenuItem{Name="Burger", Category="Mains", Price=15.99m, Description="Juicy beef burger"},
                new MenuItem{Name="Fries", Category="Sides", Price=5.99m, Description="Crispy golden fries"},
                new MenuItem{Name="Coke", Category="Drinks", Price=2.99m, Description="Chilled cola"},
                new MenuItem{Name="Caesar Salad", Category="Starters", Price=10.99m, Description="Fresh romaine lettuce"},
                new MenuItem{Name="Steak", Category="Mains", Price=25.99m, Description="10oz Ribeye"}
            };
            context.Menu.AddRange(menu);
            context.SaveChanges();
        }
    }
}
