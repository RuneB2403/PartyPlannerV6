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

        // GET: api/<OrganizersAPIController>
        [HttpGet]
        public IEnumerable<Organizer> Get()
        {
            return _context.Organizers.ToList();
        }

        // GET api/<OrganizersAPIController>/5
        [HttpGet("{name}")]
        public Organizer? Get(string name)
        {
            return _context.Organizers.FirstOrDefault(o => o.Name == name);
        }

        // POST api/<OrganizersAPIController>
        [HttpPost]
        public void Post(string name)
        {
            Organizer? organizer = new Organizer();
            organizer.Name = name;
            _context.Organizers.Add(organizer);
            _context.SaveChanges();
        }

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
