using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Touch_Bistro_App.Data;

namespace Touch_Bistro_App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly TouchBistroContext _context;

        public OrdersController(TouchBistroContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(int id)
        {
             var order = await _context.Orders.FindAsync(id);
             if (order != null) 
             {
                 order.IsPaid = true;
                 var table = await _context.Tables.FindAsync(order.TableId);
                 if (table != null)
                 {
                     table.Status = "Free";
                     table.CurrentOrderId = 0;
                 }
                 await _context.SaveChangesAsync();
             }
             return RedirectToAction("Index", "Tables");
        }
    }
}
