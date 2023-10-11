using Microsoft.AspNetCore.Mvc;
using PartyPlannerV6.Data;
using PartyPlannerV6.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashiersAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CashiersAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        /// <summary>
        /// Haalt een lijst van alle kassamedewerkers op.
        /// </summary>
        /// <returns>Een lijst van kassamedewerkers.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/cashiers
        /// </remarks>

        // GET: api/<CashiersAPIController>
        [HttpGet]
        public IEnumerable<Cashier> Get()
        {
            return _context.Cashiers.ToList();
        }

        /// <summary>
        /// Haalt een kassamedewerker op op basis van hun naam.
        /// </summary>
        /// <param name="name">De naam van de kassamedewerker om op te halen.</param>
        /// <returns>De kassamedewerker met de opgegeven naam, indien gevonden, anders null.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/cashiers/Rune Bokken
        /// </remarks>

        // GET api/<CashiersAPIController>/5
        [HttpGet("{name}")]
        public Cashier? Get(string name)
        {
            return _context.Cashiers.FirstOrDefault(c => c.Name == name);
        }


        /// <summary>
        /// Voegt een nieuwe kassamedewerker toe met de opgegeven naam.
        /// </summary>
        /// <param name="name">De naam van de nieuwe kassamedewerker.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// POST /api/cashiers
        /// Request Body: "Rune Bokken"
        /// </remarks>

        // POST api/<CashiersAPIController>
        [HttpPost]
        public void Post([FromBody] string name)
        {
            Cashier? cashier = new Cashier();
            cashier.Name = name;
            _context.Cashiers.Add(cashier);
            _context.SaveChanges();
        }


        /// <summary>
        /// Wijzigt de naam van een kassamedewerker op basis van hun ID.
        /// </summary>
        /// <param name="id">Het ID van de kassamedewerker die moet worden gewijzigd.</param>
        /// <param name="nameChange">De nieuwe naam voor de kassamedewerker.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// PUT /api/cashiers/1
        /// Request Body: "NewName"
        /// </remarks>

        // PUT api/<CashiersAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, string nameChange)
        {
            Cashier? cashierChange = _context.Cashiers.FirstOrDefault(c => c.CashierId == id);
            if (cashierChange != null)
            {
                cashierChange.Name = nameChange;
                _context.Update(cashierChange);
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Verwijdert een kassamedewerker op basis van hun naam.
        /// </summary>
        /// <param name="nameDelete">De naam van de kassamedewerker die moet worden verwijderd.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// DELETE /api/cashiers/Rune Bokkken
        /// </remarks>

        // DELETE api/<CashiersAPIController>/5
        [HttpDelete("{nameDelete}")]
        public void Delete(string nameDelete)
        {
            Cashier? cashierDelete = _context.Cashiers.FirstOrDefault(c => c.Name == nameDelete);
            _context.Cashiers.Remove(cashierDelete);
            _context.SaveChanges();
        }
    }
}
