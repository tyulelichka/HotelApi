
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        PostgresContext db = new PostgresContext();
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        
        public IEnumerable<User> Get()
        {

            var Users = db.Users.ToList();
            return (IEnumerable< User>)Users;
; 
        }


        [HttpPost]
        public void Post([FromBody] User r)
        {
            db.Users.AddRange(r);
            db.SaveChanges();

        }
        [HttpPut]
        public async Task<ActionResult<User>> Put(User i)
        {
            if (i == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == i.Id))
            {
                return NotFound();
            }

            db.Update(i);
            await db.SaveChangesAsync();
            return Ok(i);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User Users = db.Users.FirstOrDefault(x => x.Id == id);
            if (Users == null)
            {
                return NotFound();
            }
            db.Users.Remove(Users);
            await db.SaveChangesAsync();
            return Ok(Users);
        }
    }
}

