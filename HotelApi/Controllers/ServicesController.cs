using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace HotelApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        PostgresContext db = new PostgresContext();
        public ServicesController(ILogger<ServicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetServices")]

        public IEnumerable<Services> Get()
        {

            var user = db.Servicess.ToList();
            return (IEnumerable<Services>)user;
            
        }

        [HttpPost]
        public void Post([FromBody] Services r)
        {
            db.Servicess.AddRange(r);
            db.SaveChanges();

        }
        [HttpPut]
        public async Task<ActionResult<Services>> Put(Services i)
        {
            if (i == null)
            {
                return BadRequest();
            }
            if (!db.Servicess.Any(x => x.id_services == i.id_services))
            {
                return NotFound();
            }

            db.Update(i);
            await db.SaveChangesAsync();
            return Ok(i);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Services>> Delete(int id)
        {
            Services Servicess = db.Servicess.FirstOrDefault(x => x.id_services == id);
            if (Servicess == null)
            {
                return NotFound();
            }
            db.Servicess.Remove(Servicess);
            await db.SaveChangesAsync();
            return Ok(Servicess);
        }
    }
}

