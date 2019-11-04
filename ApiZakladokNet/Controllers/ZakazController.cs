using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiZakladokNet.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiZakladokNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZakazController : ControllerBase
    {
        private readonly EFContext context;
        private readonly IHostingEnvironment appEnvironment;
        public ZakazController(EFContext ccontext, IHostingEnvironment appenv)
        {
            context = ccontext;
            appEnvironment = appenv;
        }


        [HttpGet("getZakaz")]
        public ContentResult GetZakaz()
        {
            List<ZakazClient> zakaz = context.Dbzakaz.ToList();
            string json = JsonConvert.SerializeObject(zakaz);
            return Content(json, "application/json");
        }

        [HttpPost("addZakaz")]
        public ContentResult AddZakaz([FromBody]ZakazClient model)
        {
            try
            {
                ZakazClient zakazz = new ZakazClient()
                {
                    Name=model.Name,
                    Quantity=model.Quantity,
                    Description =model.Description
                };
                context.Dbzakaz.Add(zakazz);
                context.SaveChanges();
                return Content("Zakaz Added");
            }
            catch (Exception ex)
            {
                return Content("Error " + ex.Message);
            }
        }
        [HttpDelete("deleteZakaz/{id}")]
        public ContentResult deletezakaz(int id, [FromBody]ZakazClient model)
        {
            var zakaz = context.Dbzakaz.FirstOrDefault(t => t.Id == id);
            if (zakaz != null)
            {
                context.Remove(zakaz);
                context.SaveChanges();
                return Content("deleted zakaz");
            }
            else return Content("Didnt delete zakaz");
        }
    }
}