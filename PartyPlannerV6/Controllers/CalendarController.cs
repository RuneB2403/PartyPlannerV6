using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyPlannerV6.Models;
using PartyPlannerV6.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyPlannerV6.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Calendar()
        {
            DateTime currentDate = DateTime.Now;
            List<Event> pastEvents = _context.Events.Where(e => e.DateTime < currentDate).OrderBy(e => e.DateTime).ToList();
            List<Event> upcomingEvents = _context.Events.Where(e => e.DateTime >= currentDate).OrderBy(e => e.DateTime).ToList();

            ViewData["Eerdere evenementen"] = pastEvents;
            ViewData["Aankomende evenementen"] = upcomingEvents;

            return View();
        }
    }
}
