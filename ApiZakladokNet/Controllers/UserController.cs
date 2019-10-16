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
                    Password = model.Password
                };
                context.Dbuser.Add(users);
                context.SaveChanges();
                return Content("Order successfuly added");
            }
            catch (Exception ex)
            {
                return Content("Error " + ex.Message);
            }
        }
    }
}