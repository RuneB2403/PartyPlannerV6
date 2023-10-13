using Microsoft.AspNetCore.Mvc;
using PartyPlannerV6.Data;
using PartyPlannerV6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersAPIController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Haalt een lijst van alle bestellingen op.
        /// </summary>
        /// <returns>Een lijst van bestellingen.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/orders
        /// </remarks>

        // GET: api/<OrdersAPIController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }


        /// <summary>
        /// Haalt een specifieke bestelling op op basis van het ID.
        /// </summary>
        /// <param name="id">Het ID van de bestelling om op te halen.</param>
        /// <returns>De bestelling met het opgegeven ID, indien gevonden, anders null.</returns>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// GET /api/orders/1
        /// </remarks>

        // GET api/<OrdersAPIController>/5
        [HttpGet("{id}")]
        public Order? Get(int id)
        {
            return _context.Orders.FirstOrDefault(c => c.OrderId == id);
        }


        /// <summary>
        /// Maakt een nieuwe bestelling voor een evenement en voegt deze toe aan de lijst van bestellingen.
        /// </summary>
        /// <param name="eventId">Het ID van het evenement waarvoor de bestelling wordt gemaakt.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// POST /api/orders
        /// Request Body: 
        /// {
        ///     "eventId": 1
        /// }
        /// </remarks>

        // POST api/<OrdersAPIController>
        [HttpPost]
        public void Post(string eventName)
        {
            Order order = new Order();
            order.EventName = eventName;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }


        /// <summary>
        /// Wijzigt het evenement gekoppeld aan een bestelling op basis van het bestellings-ID.
        /// </summary>
        /// <param name="id">Het ID van de bestelling die moet worden gewijzigd.</param>
        /// <param name="eventIdChange">Het nieuwe evenement-ID waaraan de bestelling moet worden gekoppeld.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// PUT /api/orders/1
        /// Request Body: 
        /// {
        ///     "eventIdChange": 2
        /// }
        /// </remarks>

        // PUT api/<OrdersAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, string eventNameChange)
        {
            Order? orderUpdate = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (orderUpdate != null)
            {
                orderUpdate.EventName = eventNameChange;
                _context.Orders.Update(orderUpdate);
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Verwijdert een specifieke bestelling op basis van het bestellings-ID.
        /// </summary>
        /// <param name="idDelete">Het ID van de bestelling die moet worden verwijderd.</param>
        /// <remarks>
        /// Voorbeeldverzoek:
        /// DELETE /api/orders/1
        /// </remarks>

        // DELETE api/<OrdersAPIController>/5
        [HttpDelete("{idDelete}")]
        public void Delete(int idDelete)
        {
            Order? orderDelete = _context.Orders.FirstOrDefault(o => o.OrderId == idDelete);
            _context.Orders.Remove(orderDelete);
            _context.SaveChanges();
        }
    }
}
