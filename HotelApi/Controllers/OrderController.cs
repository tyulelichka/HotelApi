
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        PostgresContext db = new PostgresContext();
        public OrderController(ILogger<OrderController> logger)
        {
            
            _logger = logger;
        }

        [HttpGet(Name = "GetOrder")]
       
        public IEnumerable<Order> Get()
        {
            var Orders = db.Orders.ToList();
            return (IEnumerable<Order>)Orders;

        }


        [HttpPost]
        public void Post([FromBody] Order r)
        {
          db.Orders.AddRange(r);
            db.SaveChanges();

        }
     
        [HttpPut]
        public async Task<ActionResult<Order>> Put(Order i)
        {
            if (i == null)
            {
                return BadRequest();
            }
            if (!db.Orders.Any(x => x.Id == i.Id))
            {
                return NotFound();
            }

            db.Update(i);
            await db.SaveChangesAsync();
            return Ok(i);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            Order Orders = db.Orders.FirstOrDefault(x => x.Id == id);
            if (Orders == null)
            {
                return NotFound();
            }
            db.Orders.Remove(Orders);
            await db.SaveChangesAsync();
            return Ok(Orders);
        }
    }
}
