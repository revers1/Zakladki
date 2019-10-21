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
    //[Route("api/[controller]")]
    //[ApiController]
    //public class OrderController : ControllerBase
    //{
    //    private readonly EFContext context;
    //    private readonly IHostingEnvironment appEnvironment;
    //    public OrderController(EFContext ccontext, IHostingEnvironment appenv)
    //    {
    //        context = ccontext;
    //        appEnvironment = appenv;
    //    }


    //    [HttpGet("getProduct")]
    //    public ContentResult GetProducts()
    //    {
    //        List<Order> order = context.Dborder.ToList();
    //        string json = JsonConvert.SerializeObject(order);
    //        return Content(json, "application/json");
    //    }
    //}
}