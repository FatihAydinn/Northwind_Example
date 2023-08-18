using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind_Example.Models;

namespace Northwind_Example.Controllers
{
    public class OrderController : Controller
    {
        private readonly NorthwindDbContext _context;
        public OrderController(NorthwindDbContext context)
        {
            _context = context;
        }

        public IActionResult OrderList(int id)
        {
            List<Order> orders = _context.Orders.Where(x => x.EmployeeId == id).ToList();
            return View(orders);
        }

        public IActionResult ProductDetail(int id)
        {
            var orderDetails = _context.OrderDetails
                .Where(od => od.OrderId == id)
                .Include(od => od.Product)
                .ToList();

            return View(orderDetails);
        }
    }
}
