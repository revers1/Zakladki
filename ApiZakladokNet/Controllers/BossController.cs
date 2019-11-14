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
            List<Boss> bosses = _context.Bosses.ToList();
            string json = JsonConvert.SerializeObject(bosses);
            return Content(json, "application/json");
        }

        [HttpPost("addBoss")]
        public ContentResult AddBoss([FromBody]BossViewModel model)
        {
            try
            {
                Boss boss = new Boss()
                {
                    Username = model.UserName,
                    Password = model.Password
                };

                _context.Bosses.Add(boss);
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
            var boss = _context.Bosses.FirstOrDefault(t => t.Username == model.Login && t.Password == model.Password /*&& t.RoleOf.Name=="Boss"*/);
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