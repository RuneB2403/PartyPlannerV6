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


        /// <summary>
        /// Haalt een lijst van alle deelnemers op.
        /// </summary>
        /// <returns>Een lijst van deelnemers.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/participants
        /// </remarks>

        // GET: api/<ParticipantsAPIController>
        [HttpGet]
        public IEnumerable<Participant> Get()
        {
            return _context.Participants.ToList();
        }


        /// <summary>
        /// Haalt een specifieke deelnemer op op basis van hun naam.
        /// </summary>
        /// <param name="name">De naam van de deelnemer om op te halen.</param>
        /// <returns>De deelnemer met de opgegeven naam, indien gevonden, anders null.</returns>
        /// <remarks:
        /// Voorbeeldverzoek:
        /// GET /api/participants/Rune Bokken
        /// </remarks>

        // GET api/<ParticipantsAPIController>/5
        [HttpGet("{name}")]
        public Participant? Get(string name)
        {
            return _context.Participants.FirstOrDefault(p => p.Name == name);
        }


        /// <summary>
        /// Maakt een nieuwe deelnemer en voegt deze toe aan de lijst van deelnemers.
        /// </summary>
        /// <param name="name">De naam van de nieuwe deelnemer.</param>
        /// <remarks:
        /// Voorbeeldverzoek:
        /// POST /api/participants
        /// Request Body: "Rune Bokken"
        /// </remarks>

        // POST api/<ParticipantsAPIController>
        [HttpPost]
        public void Post(string name)
        {
            Participant participant = new Participant();
            participant.Name = name;
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }


        /// <summary>
        /// Wijzigt de naam van een deelnemer op basis van hun huidige naam.
        /// </summary>
        /// <param name="name">De huidige naam van de deelnemer die moet worden gewijzigd.</param>
        /// <param name="nameChange">De nieuwe naam voor de deelnemer.</param>
        /// <remarks:
        /// Voorbeeldverzoek:
        /// PUT /api/participants/Rune Bokken
        /// Request Body: "NieuweNaam"
        /// </remarks>

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


        /// <summary>
        /// Verwijdert een deelnemer op basis van hun naam.
        /// </summary>
        /// <param name="nameDelete">De naam van de deelnemer die moet worden verwijderd.</param>
        /// <remarks:
        /// Voorbeeldverzoek:
        /// DELETE /api/participants/Rune Bokken
        /// </remarks

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
