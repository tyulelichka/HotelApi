
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        PostgresContext db = new PostgresContext();
        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMenu")]
        public IEnumerable<Menu> Get()
        {
            var Menus = db.Menus.ToList();
            return (IEnumerable<Menu>)Menus;
        }


        [HttpPost]
        public void Post([FromBody] Menu r)
        {
            db.Menus.AddRange(r);
            db.SaveChanges();

        }
        [HttpPut]
      
        public async Task<ActionResult<Menu>> Put(Menu i)
        {
            if (i == null)
            {
                return BadRequest();
            }
            if (!db.Menus.Any(x => x.Id == i.Id))
            {
                return NotFound();
            }

            db.Update(i);
            await db.SaveChangesAsync();
            return Ok(i);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Menu>> Delete(int id)
        {
            Menu Menus = db.Menus.FirstOrDefault(x => x.Id == id);
            if (Menus == null)
            {
                return NotFound();
            }
            db.Menus.Remove(Menus);
            await db.SaveChangesAsync();
            return Ok(Menus);
        }
    }
}
