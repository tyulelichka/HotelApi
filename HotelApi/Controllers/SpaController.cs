
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpaController : ControllerBase
    {
        private readonly ILogger<SpaController> _logger;
        PostgresContext db = new PostgresContext();
        public SpaController(ILogger<SpaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSpa")]
      
        public IEnumerable<Spa> Get()
        {
            var Spas = db.Spas.ToList();
            return (IEnumerable<Spa>)Spas;
        }


        [HttpPost]
        public void Post([FromBody] Spa r)
        {
            db.Spas.AddRange(r);
            db.SaveChanges();

        }
        [HttpPut]
        public async Task<ActionResult<Spa>> Put(Spa i)
        {
            if (i == null)
            {
                return BadRequest();
            }
            if (!db.Spas.Any(x => x.Id == i.Id))
            {
                return NotFound();
            }

            db.Update(i);
            await db.SaveChangesAsync();
            return Ok(i);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spa>> Delete(int id)
        {
            Spa Spas = db.Spas.FirstOrDefault(x => x.Id == id);
            if (Spas == null)
            {
                return NotFound();
            }
            db.Spas.Remove(Spas);
            await db.SaveChangesAsync();
            return Ok(Spas);
        }
    }
}
