using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyPlannerV6.Data;
using PartyPlannerV6.Models;
using System.Diagnostics;

namespace PartyPlannerV6.Controllers
{
    public class CashRegisterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public CashRegisterController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult CashRegister()
        {
            // Haal evenementen op uit de database en geef ze door aan de weergave
            List<Order> orders = _context.Orders.ToList();
            return View(orders);
        }
        [HttpPost]
        public IActionResult UpdatePaymentStatus(int orderId, bool isChecked)
        {
            // Zoek de order in de database op basis van orderId en werk de betaalstatus bij
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.Payed = isChecked;
                _context.SaveChanges(); // Opslaan van de wijziging in de database
                return Ok(); // Terugkeren met een succesvolle status (HTTP 200 OK)
            }
            return NotFound(); // Order niet gevonden
        }
    }
}
