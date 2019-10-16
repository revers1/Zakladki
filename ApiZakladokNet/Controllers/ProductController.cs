using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiZakladokNet.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiZakladokNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EFContext context;
        private readonly IHostingEnvironment appEnvironment;
        public ProductController(EFContext ccontext, IHostingEnvironment appenv)
        {
            context = ccontext;
            appEnvironment = appenv;
        }

        
    }
}