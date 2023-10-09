using Microsoft.AspNetCore.Mvc;
using PartyPlannerV6.Data;
using PartyPlannerV6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<EventsAPIController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events.ToList();
        }

        // GET api/<EventsAPIController>/5
        [HttpGet("{id}")]
        public Event? Get(int id)
        {
            return _context.Events.FirstOrDefault(c => c.EventId == id);
        }

        // POST api/<EventsAPIController>
        [HttpPost]
        public void Post(string name, string description, string category, string location, DateTime dateTime, float costs, int availableParticipants, int currentParticipants)
        {
            Event eventMake = new Event();
            eventMake.Name = name;
            eventMake.Description = description;
            eventMake.Category = category;
            eventMake.Location = location;
            eventMake.DateTime = dateTime;
            eventMake.Costs = costs;
            eventMake.AvailableParticipants = availableParticipants;
            eventMake.CurrentParticipants = currentParticipants;
            _context.Events.Add(eventMake);
            _context.SaveChanges();
        }

        // PUT api/<EventsAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, string nameChange)
        {
            Event? eventUpdate = _context.Events.FirstOrDefault(c => c.EventId == id);
            if (eventUpdate != null)
            {
                eventUpdate.Name = nameChange;
                _context.Events.Update(eventUpdate);
                _context.SaveChanges();
            }
        }

        // DELETE api/<EventsAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event? eventDelete = _context.Events.FirstOrDefault(e => e.EventId == id);
            _context.Events.Remove(eventDelete);
            _context.SaveChanges();
        }
    }
}
