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

        /// <summary>
        /// Haalt een lijst van alle evenementen op.
        /// </summary>
        /// <returns>Een lijst van evenementen.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/events
        /// </remarks>

        // GET: api/<EventsAPIController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events.ToList();
        }


        /// <summary>
        /// Haalt een specifiek evenement op op basis van het ID.
        /// </summary>
        /// <param name="id">Het ID van het evenement om op te halen.</param>
        /// <returns>Het evenement met het opgegeven ID, indien gevonden, anders null.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/events/1
        /// </remarks>

        // GET api/<EventsAPIController>/5
        [HttpGet("{id}")]
        public Event? Get(int id)
        {
            return _context.Events.FirstOrDefault(c => c.EventId == id);
        }


        /// <summary>
        /// Maakt een nieuw evenement en voegt het toe aan de lijst van evenementen.
        /// </summary>
        /// <param name="name">Naam van het evenement.</param>
        /// <param name="description">Beschrijving van het evenement.</param>
        /// <param name="category">Categorie van het evenement.</param>
        /// <param name="location">Locatie van het evenement.</param>
        /// <param name="dateTime">Datum en tijd van het evenement.</param>
        /// <param name="costs">Kosten van het evenement.</param>
        /// <param name="availableParticipants">Aantal beschikbare deelnemers.</param>
        /// <param name="currentParticipants">Aantal huidige deelnemers.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// POST /api/events
        /// Request Body: 
        /// {
        ///     "name": "Feestavond",
        ///     "description": "Een geweldige feestavond",
        ///     "category": "Feest",
        ///     "location": "Party Hall",
        ///     "dateTime": "2023-10-11T19:00:00",
        ///     "costs": 20.0,
        ///     "availableParticipants": 100,
        ///     "currentParticipants": 0
        /// }
        /// </remarks>

        // POST api/<EventsAPIController>
        [HttpPost]
        public void Post(string name, string description, /*string category,*/ string location, DateTime dateTime, float costs, int availableParticipants, int currentParticipants)
        {
            Event eventMake = new Event();
            eventMake.Name = name;
            eventMake.Description = description;
            //eventMake.Category = category;
            eventMake.Location = location;
            eventMake.DateTime = dateTime;
            eventMake.Costs = costs;
            eventMake.AvailableParticipants = availableParticipants;
            eventMake.CurrentParticipants = currentParticipants;
            _context.Events.Add(eventMake);
            _context.SaveChanges();
        }


        /// <summary>
        /// Wijzigt de naam van een specifiek evenement op basis van het ID.
        /// </summary>
        /// <param name="id">Het ID van het evenement dat moet worden gewijzigd.</param>
        /// <param name="nameChange">De nieuwe naam voor het evenement.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// PUT /api/events/1
        /// Request Body: "NieuweNaam"
        /// </remarks>

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


        /// <summary>
        /// Verwijdert een specifiek evenement op basis van het ID.
        /// </summary>
        /// <param name="id">Het ID van het evenement dat moet worden verwijderd.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// DELETE /api/events/1
        /// </remarks>

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
