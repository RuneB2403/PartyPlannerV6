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

        // GET: api/<OrdersAPIController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }

        // GET api/<OrdersAPIController>/5
        [HttpGet("{id}")]
        public Order? Get(int id)
        {
            return _context.Orders.FirstOrDefault(c => c.OrderId == id);
        }

        // POST api/<OrdersAPIController>
        [HttpPost]
        public void Post(int eventId)
        {
            Order order = new Order();
            order.EventId = eventId;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // PUT api/<OrdersAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, int eventIdChange)
        {
            Order? orderUpdate = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (orderUpdate != null)
            {
                orderUpdate.EventId = eventIdChange;
                _context.Orders.Update(orderUpdate);
                _context.SaveChanges();
            }
        }

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
