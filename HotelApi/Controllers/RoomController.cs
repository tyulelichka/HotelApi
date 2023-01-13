

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        PostgresContext db = new PostgresContext();
        public RoomController(ILogger<RoomController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRoom")]
        public IEnumerable<Room> Get()
        {
            var rooms = db.Rooms.ToList();
                return (IEnumerable<Room>)rooms;
        }

     
        [HttpPost]
        public void Post([FromBody] Room r)
        {
            db.Rooms.AddRange(r);
                db.SaveChanges();
            
        }
        



        [HttpPut]
        public async Task<ActionResult<Room>> Put(Room i)
        {
            if (i == null)
            {
                return BadRequest();
            }
            if (!db.Rooms.Any(x => x.Id == i.Id))
            {
                return NotFound();
            }

            db.Update(i);
            await db.SaveChangesAsync();
            return Ok(i);
        }










        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> Delete(int id)
        {
            Room rooms = db.Rooms.FirstOrDefault(x => x.Id == id);
            if (rooms == null)
            {
                return NotFound();
            }
            db.Rooms.Remove(rooms);
            await db.SaveChangesAsync();
            return Ok(rooms);
        }
    }
}





