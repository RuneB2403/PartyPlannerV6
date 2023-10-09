using Microsoft.AspNetCore.Mvc;
using PartyPlannerV6.Data;
using PartyPlannerV6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ParticipantsAPIController>
        [HttpGet]
        public IEnumerable<Participant> Get()
        {
            return _context.Participants.ToList();
        }

        // GET api/<ParticipantsAPIController>/5
        [HttpGet("{name}")]
        public Participant? Get(string name)
        {
            return _context.Participants.FirstOrDefault(p => p.Name == name);
        }

        // POST api/<ParticipantsAPIController>
        [HttpPost]
        public void Post(string name)
        {
            Participant participant = new Participant();
            participant.Name = name;
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }

        // PUT api/<ParticipantsAPIController>/5
        [HttpPut("{name}")]
        public void Put(string name, string nameChange)
        {
            Participant? participantUpdate = _context.Participants.FirstOrDefault(p => p.Name == name);
            if (participantUpdate != null)
            {
                participantUpdate.Name = nameChange;
                _context.Update(participantUpdate);
                _context.SaveChanges();
            }
        }

        // DELETE api/<ParticipantsAPIController>/5
        [HttpDelete("{nameDelete}")]
        public void Delete(string nameDelete)
        {
            Participant? participantDelete = _context.Participants.FirstOrDefault(p => p.Name == nameDelete);
            _context.Participants.Remove(participantDelete);
            _context.SaveChanges();
        }
    }
}
