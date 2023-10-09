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

        // GET: api/<CashiersAPIController>
        [HttpGet]
        public IEnumerable<Cashier> Get()
        {
            return _context.Cashiers.ToList();
        }

        // GET api/<CashiersAPIController>/5
        [HttpGet("{name}")]
        public Cashier? Get(string name)
        {
            return _context.Cashiers.FirstOrDefault(c => c.Name == name);
        }

        // POST api/<CashiersAPIController>
        [HttpPost]
        public void Post([FromBody] string name)
        {
            Cashier? cashier = new Cashier();
            cashier.Name = name;
            _context.Cashiers.Add(cashier);
            _context.SaveChanges();
        }

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
