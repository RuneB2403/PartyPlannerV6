using Microsoft.AspNetCore.Mvc;
using PartyPlannerV6.Data;
using PartyPlannerV6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganizersAPIController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Haalt een lijst van alle organisatoren op.
        /// </summary>
        /// <returns>Een lijst van organisatoren.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/organizers
        /// </remarks>

        // GET: api/<OrganizersAPIController>
        [HttpGet]
        public IEnumerable<Organizer> Get()
        {
            return _context.Organizers.ToList();
        }


        /// <summary>
        /// Haalt een specifieke organisator op op basis van hun naam.
        /// </summary>
        /// <param name="name">De naam van de organisator om op te halen.</param>
        /// <returns>De organisator met de opgegeven naam, indien gevonden, anders null.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/organizers/Rune Bokken
        /// </remarks>

        // GET api/<OrganizersAPIController>/5
        [HttpGet("{name}")]
        public Organizer? Get(string name)
        {
            return _context.Organizers.FirstOrDefault(o => o.Name == name);
        }


        /// <summary>
        /// Maakt een nieuwe organisator en voegt deze toe aan de lijst van organisatoren.
        /// </summary>
        /// <param name="name">De naam van de nieuwe organisator.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// POST /api/organizers
        /// Request Body: "Rune Bokken"
        /// </remarks>

        // POST api/<OrganizersAPIController>
        [HttpPost]
        public void Post(string name)
        {
            Organizer? organizer = new Organizer();
            organizer.Name = name;
            _context.Organizers.Add(organizer);
            _context.SaveChanges();
        }


        /// <summary>
        /// Wijzigt de naam van een organisator op basis van hun huidige naam.
        /// </summary>
        /// <param name="name">De huidige naam van de organisator die moet worden gewijzigd.</param>
        /// <param name="nameChange">De nieuwe naam voor de organisator.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// PUT /api/organizers/Rune Bokken
        /// Request Body: "NieuweNaam"
        /// </remarks>

        // PUT api/<OrganizersAPIController>/5
        [HttpPut("{name}")]
        public void Put(string name, string nameChange)
        {
            Organizer? organizerUpdate = _context.Organizers.FirstOrDefault(o => o.Name == name);
            if (organizerUpdate != null)
            {
                organizerUpdate.Name = nameChange;
                _context.Update(organizerUpdate);
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Verwijdert een organisator op basis van hun naam.
        /// </summary>
        /// <param name="nameDelete">De naam van de organisator die moet worden verwijderd.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// DELETE /api/organizers/Rune Bokken
        /// </remarks>

        // DELETE api/<OrganizersAPIController>/5
        [HttpDelete("{nameDelete}")]
        public void Delete(string nameDelete)
        {
            Organizer? organizerDelete = _context.Organizers.FirstOrDefault(o => o.Name == nameDelete);
            _context.Organizers.Remove(organizerDelete);
            _context.SaveChanges();
        }
    }
}
