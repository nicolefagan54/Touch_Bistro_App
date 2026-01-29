using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Touch_Bistro_App.Data;
using Touch_Bistro_App.Models;

namespace Touch_Bistro_App.Controllers
{
    public class MenuController : Controller
    {
        private readonly TouchBistroContext _context;

        public MenuController(TouchBistroContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View(await _context.Menu.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddToOrder(int orderId, int menuItemId)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId);
            
            var menuItem = await _context.Menu.FindAsync(menuItemId);

            if (order != null && menuItem != null)
            {
                var existingItem = order.Items.FirstOrDefault(i => i.MenuItemId == menuItemId);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    order.Items.Add(new OrderItem
                    {
                        MenuItemId = menuItemId,
                        MenuItem = menuItem,
                        Quantity = 1
                    });
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", new { orderId });
        }

        public IActionResult GoToOrder(int orderId)
        {
            return RedirectToAction("Details", "Orders", new { id = orderId });
        }
    }
}
