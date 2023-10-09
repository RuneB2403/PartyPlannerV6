using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyPlannerV6.Models;
using PartyPlannerV6.Data;

namespace PartyPlannerV6.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CalendarController( ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Calendar()
        {
            List<Event> events = _context.Events.ToList();
            return View(events);
        }
    }
}
