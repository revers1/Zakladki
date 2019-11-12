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
    public class UserController : ControllerBase
    {
        private readonly EFContext context;

        public UserController(EFContext ccontext)
        { context = ccontext; }

       
        [HttpGet("getUser")]
        public ContentResult GetUsers()
        {
            List<User> userr = context.Dbuser.ToList();
            string json = JsonConvert.SerializeObject(userr);
            return Content(json, "application/json");
        }
        [HttpPost("addUser")]
        public ContentResult AddUser([FromBody]UserViewModel model)
        {
            try
            {
                User users = new User()
                {
                    Login = model.Login,
                    Password = model.Password,
                    Roles_Id=1,
                    IsBlocked = false
                    
                };
                context.Dbuser.Add(users);
                context.SaveChanges();
                return Content("User Added");
            }
            catch (Exception ex)
            {
                return Content("Error " + ex.Message);
            }
        }
        [HttpDelete("deleteUser/{id}")]
        public ContentResult deletecategory(int id, [FromBody]UserViewModel model)
        {
            var user = context.Dbuser.FirstOrDefault(t => t.Id == id);
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
                return Content("deleted user");
            }
            else return Content("Didnt delete user");
        }
        [HttpPost("loginUser")]
        public IActionResult CheckLogin([FromBody]LogInViewModel model)
        {
            var user = context.Dbuser.FirstOrDefault(t => t.Login == model.Login && t.Password == model.Password);
            if (user != null)
            {
               return this.Ok(new { UserId = user.Id.ToString(), RoleName = user.RoleOf.Name });
            }
            else
            {
                return this.BadRequest();
            }
        }
        [HttpPost("blockUser")]
        public IActionResult BlockUser(int id)
        {
            var block = context.Dbuser.FirstOrDefault(t => t.Id == id).IsBlocked = true;
            context.SaveChanges();
            return Ok();
        }
        [HttpPost("unblockUser")]
        public IActionResult UnbockUser(int id)
        {
            var block = context.Dbuser.FirstOrDefault(t => t.Id == id).IsBlocked = false;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("deleteUser/{id}")]
        public IActionResult ChangeRoleOfUser(int id)
        {
            var user = context.Dbuser.FirstOrDefault(t => t.Id == id);
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}