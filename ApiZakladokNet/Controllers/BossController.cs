using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiZakladokNet.Entity;
using ApiZakladokNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiZakladokNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BossController : ControllerBase
    {
        private readonly EFContext _context;

        public BossController(EFContext context)
        { _context = context; }


        [HttpGet("getBoss")]
        public ContentResult GetBoss()
        {
            List<User> bosses = _context.Dbuser.ToList();
            string json = JsonConvert.SerializeObject(bosses);
            return Content(json, "application/json");
        }

        [HttpPost("addBoss")]
        public ContentResult AddBoss([FromBody]BossViewModel model)
        {
            try
            {
                User user = new User()
                {
                    Login = model.UserName,
                    Password = model.Password
                };

                _context.Dbuser.Add(user);
                _context.SaveChanges();
                return Content("Boss Added");
            }
            catch (Exception ex)
            {
                return Content("Error " + ex.Message);
            }
        }

        [HttpPost("loginBoss")]
        public IActionResult CheckLogin([FromBody]LogInViewModel model)
        {
            var boss = _context.Dbuser.FirstOrDefault(t => t.Login == model.Login && t.Password == model.Password && t.RoleOf.Name=="Boss");
            if (boss != null)
            {
                return Ok(boss.Id.ToString());
            }
            else
            {
                return BadRequest();
            }
        }
    }
}