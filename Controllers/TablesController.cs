using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Touch_Bistro_App.Data;
using Touch_Bistro_App.Models;
using System.Threading.Tasks;

namespace Touch_Bistro_App.Controllers
{
    public class TablesController : Controller
    {
        private readonly TouchBistroContext _context;

        public TablesController(TouchBistroContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tables.ToListAsync());
        }

        public async Task<IActionResult> Select(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return NotFound();

            if (table.CurrentOrderId == 0)
            {
                // Create new order
                var order = new Order { TableId = table.Id };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                table.CurrentOrderId = order.Id;
                table.Status = "Occupied";
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Menu", new { orderId = table.CurrentOrderId });
        }
    }
}
