using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiZakladokNet.Entity;
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

       
        [HttpGet("user")]
        public ContentResult GetUsers()
        {
            List<User> userr = context.Dbuser.ToList();
            string json = JsonConvert.SerializeObject(userr);
            return Content(json, "application/json");
        }
    }
}